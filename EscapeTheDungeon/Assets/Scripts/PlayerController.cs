using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    private GameObject _laser;

    public Transform firePoint;

    Vector2 movement;

    public bool isFacingLeft = true;

    public Laser laser;

    void Start()
    {
        laser = GameObject.Find("Laser").GetComponent<Laser>();
        if (laser = null)
        {
            Debug.LogError("Laser not found ??");
        }
    }
    
    void Update()
    {
        //controls
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isFacingLeft)
            {
                flip();
                laser.transform.Translate(Vector3.right * laser.speed * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!isFacingLeft)
            {
                flip();
            }
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        Instantiate(_laser, firePoint.position, firePoint.rotation);
    }

    //flip chara left
    void flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
