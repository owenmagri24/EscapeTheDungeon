using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed;

    private Transform player;
    private PlayerController playerScript;
    private Vector2 target; 
    void Start()
    {
        //get player transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //get player script
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        target = new Vector2(player.position.x, player.position.y); //position of player
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime); //moves towards fixed position of player

        if(transform.position.x == target.x && transform.position.y == target.y){ //if projectile reaches fixed target (collides with nothing)
            Destroy(gameObject);
        }
    }

    void Damage(){
        playerScript.health -= 1;

        if(playerScript.health < 1){
            // Game over
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }

        else if(other.gameObject.tag == "Player")
        {
            Damage();
            Destroy(gameObject);
        }
    }
}
