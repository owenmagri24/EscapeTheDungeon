using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 15.0f;
    public Rigidbody2D rb;

    // Update is called once per frame
    
    void Start()
    {
        rb.velocity = transform.TransformDirection(Vector2.left * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
