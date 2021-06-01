using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 15.0f;
    public Rigidbody2D rb;

    SpawnManager spawnManager;

    // Update is called once per frame
    
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
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
            spawnManager.SpawnEnemy();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if(other.gameObject.tag == "Enemy2")
        {
            spawnManager.SpawnEnemy2();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if(other.gameObject.tag == "Enemy3")
        {
            spawnManager.SpawnEnemy3();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if(other.gameObject.tag == "Enemy4")
        {
            spawnManager.SpawnEnemy4();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if(other.gameObject.tag == "Enemy5")
        {
            spawnManager.SpawnEnemy5();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    //destroys bullet when spawns after set amount of time
    IEnumerator SelfDestroy(){
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
