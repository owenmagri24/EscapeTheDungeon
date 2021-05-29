using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;

    [SerializeField]
    Rigidbody2D rb;

    Vector2 movement;

    public bool isFacingLeft = true;

    public GameObject firePoint;
    public int health = 3;

    [SerializeField]
    private Text keyCounter;
    private int keyAmount;
    public GameManager GameManager;

    void Start()
    {

    }
    
    void Update()
    {
        //Movement Controls
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        keyCounter.text = "Keys: "+ keyAmount + "/3";

        DirectionalShooting();
    }

    void FixedUpdate() {
        //player movement
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void DirectionalShooting(){
        //Method to change firePoint rotation depending on keypress

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(isFacingLeft){
                flip();
                isFacingLeft = false;
            }
            firePoint.transform.rotation = Quaternion.Euler(0,0,180);
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            if(!isFacingLeft){
                flip();
                isFacingLeft = true;
            }
            firePoint.transform.rotation = Quaternion.Euler(0,0,0);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            firePoint.transform.rotation = Quaternion.Euler(0,0,-90);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            firePoint.transform.rotation = Quaternion.Euler(0,0,90);
        }

        //using keycode instead of keycodedown because both need to be pressed simultaneously
        else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)){
            firePoint.transform.rotation = Quaternion.Euler(0,0,45);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
            firePoint.transform.rotation = Quaternion.Euler(0,0,135);
        }
        else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
            firePoint.transform.rotation = Quaternion.Euler(0,0,315);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)){
            firePoint.transform.rotation = Quaternion.Euler(0,0,225);
        }
    }

    void flip()
    {
        //flips sprite depending on direction facing
        isFacingLeft = !isFacingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D col) 
        {
            if (col.gameObject.tag == "Key")
            {
                keyAmount +=1;
                Destroy(col.gameObject);
            }

            else if (col.gameObject.tag == "Door" && keyAmount == 3)
            {
                GameManager.GameComplete();
            }
        }
}
