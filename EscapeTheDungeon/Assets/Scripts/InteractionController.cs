using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public bool hasCollided = false;
    public Text eToInteract;

    public GameObject BeginDoor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colliderChecker();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasCollided = true;
            eToInteract.text = "Press 'E' to open the door";
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        hasCollided = false;
        eToInteract.text = " ";
    }

    void colliderChecker()
    {
        if (hasCollided == true && Input.GetKey(KeyCode.E))
            {
                Debug.Log("E is pressed");
            }
    }
}
