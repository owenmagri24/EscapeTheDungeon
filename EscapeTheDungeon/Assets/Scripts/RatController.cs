using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RatController : MonoBehaviour
{
    GameObject[] targets;
    int randomTarget;

    [SerializeField]
    float minDistance = 18f;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("RatTarget");
        randomTarget = Random.Range(0, targets.Length);
        gameObject.GetComponent<AIDestinationSetter>().target = targets[randomTarget].transform;
    }

    
    void Update()
    {
        //distance from rat to waypoint
        float distance = Vector3.Distance(this.transform.position,targets[randomTarget].transform.position);
        
        if (distance <=minDistance)
        {
            randomTarget = Random.Range(0, targets.Length);

            gameObject.GetComponent<AIDestinationSetter>().target = targets[randomTarget].transform;
        }
    }
}
