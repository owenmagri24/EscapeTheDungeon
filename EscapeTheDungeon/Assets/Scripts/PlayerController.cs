using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;

    [SerializeField]
    Rigidbody2D rb;

    Vector2 movement;

    public bool isFacingLeft = true;

    public GameObject firePoint;


    void Start()
    {

    }
    
    void Update()
    {
        //Movement Controls
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        DirectionalShooting();
    }

    void FixedUpdate() {
        //player movement
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void DirectionalShooting(){
        //Method to change firePoint rotation depending on keypress

        if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(isFacingLeft){
                flip();
                isFacingLeft = false;
            }
            firePoint.transform.rotation = Quaternion.Euler(0,0,180);
        }

        else if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(!isFacingLeft){
                flip();
                isFacingLeft = true;
            }
            firePoint.transform.rotation = Quaternion.Euler(0,0,0);
        }

        else if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow))
        {
            firePoint.transform.rotation = Quaternion.Euler(0,0,-90);
        }

        else if (Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow))
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
}
