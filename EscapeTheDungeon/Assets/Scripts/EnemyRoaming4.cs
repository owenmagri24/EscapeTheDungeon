using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyRoaming4 : MonoBehaviour
{
    GameObject[] targets;
    
    [SerializeField]
    int currentTarget;

    [SerializeField]
    float minDistance = 0.1f;

    public Animator animator;
    
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target4");
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
        
        Controller();
    }

    void Controller()
    {
        if (transform.rotation.eulerAngles.z < 360 && transform.rotation.eulerAngles.z > 180)
        {
            //Debug.Log("rotated downwards");
            animator.SetBool("isVertical", true);
            animator.SetFloat("vertRotation", 0);
        }

        if (transform.rotation.eulerAngles.z < 180 && transform.rotation.eulerAngles.z > 0)
        {
            //Debug.Log("rotating upwards");
            animator.SetBool("isVertical", true);
            animator.SetFloat("vertRotation", 180);
        }
    }
}

