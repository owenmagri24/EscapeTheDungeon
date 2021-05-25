using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float playerShootingDistance;

    [SerializeField]
    private Transform player;
    private float timeBetweenShots;

    [SerializeField]
    private float canShoot;
    public GameObject projectile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = canShoot;
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if(distance <= playerShootingDistance){
            GetComponent<AIPath>().maxSpeed = 0; //enemy stops if player is in range
        } else{
            GetComponent<AIPath>().maxSpeed = 3; //enemy continues if player leaves
        }

        if(timeBetweenShots <=0 && distance <= playerShootingDistance){ //cooldown on shots
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = canShoot;

        } else {
            timeBetweenShots -= Time.deltaTime;
        }

    }
}
