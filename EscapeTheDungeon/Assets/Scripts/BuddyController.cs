using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BuddyController : MonoBehaviour
{
    [SerializeField]
    private float buddyMedkitDistance;

    GameObject[] medkit;

    [SerializeField]
    private int currentTarget;
    public Transform player;

    public AIDestinationSetter aiDestinationSetter;

    public AIPath aIPath;

    private bool medkitAvailable = true;


    void Start()
    {
        medkit = GameObject.FindGameObjectsWithTag("MedKit");
    }

    
    void Update()
    {
        if(medkitAvailable == true){
            float distance = Vector2.Distance(transform.position, medkit[currentTarget].transform.position);

            if(distance <= buddyMedkitDistance)
            {
                aiDestinationSetter.GetComponent<AIDestinationSetter>().target = medkit[currentTarget].transform;
                aIPath.GetComponent<AIPath>().endReachedDistance = 1f;
            }

        }
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MedKit")
        {
            Destroy(other.gameObject);
            currentTarget++;

            if(currentTarget == medkit.Length)
            {
                medkitAvailable = false;
            }

            aiDestinationSetter.GetComponent<AIDestinationSetter>().target = player.transform;
            aIPath.GetComponent<AIPath>().endReachedDistance = 3f;
        }
    }
}
