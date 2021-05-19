using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 15.0f;
    public Rigidbody2D rb;

    // Update is called once per frame
    
    void Start()
    {
        rb.velocity = transform.TransformDirection(Vector2.left * bulletSpeed);
        StartCoroutine(SelfDestroy());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }

        else if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    //destroys bullet after set amount of time
    IEnumerator SelfDestroy(){
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
