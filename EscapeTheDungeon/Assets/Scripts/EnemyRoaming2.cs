using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyRoaming2 : MonoBehaviour
{
    GameObject[] targets;
    
    [SerializeField]
    int currentTarget;

    [SerializeField]
    float minDistance = 0.1f;

    public Animator animator;

    bool isFacingRight = true;

    
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target2");
        gameObject.GetComponent<AIDestinationSetter>().target = targets[currentTarget].transform;
    }

    void Update()
    {
        //distance from enemy to waypoint
        float distance = Vector3.Distance(this.transform.position,targets[currentTarget].transform.position);
        
        if (distance <=minDistance)
        {
            currentTarget++;

            if (currentTarget == targets.Length)
            {
                currentTarget = 0;
            }

            gameObject.GetComponent<AIDestinationSetter>().target = targets[currentTarget].transform;
        }
        
        Debug.Log(transform.rotation.eulerAngles.z);
        Controller();
    }

    void Controller()
    {
        if (transform.rotation.eulerAngles.z < 360 && transform.rotation.eulerAngles.z > 180)
        {
            Debug.Log("rotated right");
            animator.SetBool("isHorizontal", true);
            animator.SetFloat("vertRotation", 0);
        }

        if (transform.rotation.eulerAngles.z < 180 && transform.rotation.eulerAngles.z > 0)
        {
            Debug.Log("rotating left");
            animator.SetBool("isHorizontal", true);
            animator.SetFloat("vertRotation", 180);
        }
    }
}

