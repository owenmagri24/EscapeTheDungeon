using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyRoaming : MonoBehaviour
{
    GameObject[] targets;
    
    [SerializeField]
    int currentTarget;
    [SerializeField]
    float minDistance = 0.1f;
    

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        gameObject.GetComponent<AIDestinationSetter>().target = targets[currentTarget].transform;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}

