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
    public bool isFacingUp = false;

    public GameObject firePoint;


    void Start()
    {

    }
    
    void Update()
    {
        //controls
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {

            if (isFacingLeft)
            {
                flip();
                firePoint.transform.Rotate(0,0,180);
            }
        }

        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
        {
            if (!isFacingLeft)
            {
                flip();
                firePoint.transform.Rotate(0,0,180);
            }
        }

        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow))
        {
            //rotate firepoint upwards
            //shoot upwards
        }

        if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
        {
            //rotate firepoint downwards
            //shoot downwards
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
