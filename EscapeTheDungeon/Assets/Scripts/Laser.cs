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

        else if(other.gameObject.name == "Enemy_0")
        {
            spawnManager.enemyHit = 0;
            spawnManager.SpawnEnemy();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.gameObject.name == "Enemy_1")
        {
            spawnManager.enemyHit = 1;
            spawnManager.SpawnEnemy();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.gameObject.name == "Enemy_2")
        {
            spawnManager.enemyHit = 2;
            spawnManager.SpawnEnemy();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.gameObject.name == "Enemy_3")
        {
            spawnManager.enemyHit = 3;
            spawnManager.SpawnEnemy();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.gameObject.name == "Enemy_4")
        {
            spawnManager.enemyHit = 4;
            spawnManager.SpawnEnemy();
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
