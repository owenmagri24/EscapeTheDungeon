using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionDoor : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    float minDistance = 0.5f;

    public Text interactText;

    public Text objectives;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position,player.transform.position);
        
        if (distance <= minDistance)
        {
            interactText.text = "Press 'E' to open the door";
        }

        else
        {
            interactText.text = " ";
        }

        Destroy();
    }

    private void Destroy()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            interactText.text = " ";
            objectives.text = " ";
        }
    }
}
