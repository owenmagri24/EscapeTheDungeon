using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BuddyController : MonoBehaviour
{
    [SerializeField]
    private float buddyMedkitDistance;
    public Transform player;

    private PlayerController playerScript;

    public AIDestinationSetter aiDestinationSetter;

    public AIPath aIPath;

    private bool medkitAvailable = true;
    GameObject[] medkits;

    void Start() {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(medkitAvailable == true){
            //find distance between buddy and closest medkit
            float distance = Vector2.Distance(transform.position, FindClosestMedkit().transform.position);

            if(distance <= buddyMedkitDistance && playerScript.health < 3)
            {
                //medkit set as target
                aiDestinationSetter.GetComponent<AIDestinationSetter>().target = FindClosestMedkit().transform;
                //endReachedDistance set to 1 to go on top of target
                aIPath.GetComponent<AIPath>().endReachedDistance = 1f;
            }
        }
    }

    //function to find and return closestmedkit as gameobject
    public GameObject FindClosestMedkit(){
        medkits = GameObject.FindGameObjectsWithTag("MedKit");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 buddyPosition = transform.position;

        foreach (GameObject medkit in medkits){
            Vector3 difference = medkit.transform.position - buddyPosition;
            float curDistance = difference.sqrMagnitude;
            if(curDistance < distance){
                closest = medkit;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MedKit" && playerScript.health < 3)
        {
            Destroy(other.gameObject);
            playerScript.health +=1;

            //no medkits left on the map
            if(medkits.Length <= 1){
                medkitAvailable = false;
            }

            //changes target to player after collision with medkit
            aiDestinationSetter.GetComponent<AIDestinationSetter>().target = player.transform;
            //change endReachedDistance to 3f so hes not too close to player
            aIPath.GetComponent<AIPath>().endReachedDistance = 3f;
        }
    }

    //ignores player collision
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
