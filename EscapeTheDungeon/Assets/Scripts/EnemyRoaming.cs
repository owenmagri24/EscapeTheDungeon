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

    public Animator animator;

    SpriteRenderer m_spriteRenderer;

    [SerializeField]
    bool isNotRotated = true;
    
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        gameObject.GetComponent<AIDestinationSetter>().target = targets[currentTarget].transform;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
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

        //Debug.Log(transform.rotation.eulerAngles.z);
        
        Controller();
    }

    void Controller()
    {
        if (transform.rotation.eulerAngles.z < 360 && transform.rotation.eulerAngles.z > 180)
        {
            //Debug.Log("Walking Forward");
            animator.SetBool("isVertical", true);
            animator.SetFloat("vertRotation", 0);

            if (isNotRotated)
            {
                m_spriteRenderer.flipY = true;
                isNotRotated = false;
            }
        }

        if (transform.rotation.eulerAngles.z < 180 && transform.rotation.eulerAngles.z > 0)
        {
            //Debug.Log("Walking Back");
            animator.SetBool("isVertical", true);
            animator.SetFloat("vertRotation", 180);
            
            if (!isNotRotated)
            {
                m_spriteRenderer.flipY = false;
                isNotRotated = true;
            }
        }
    }
}

