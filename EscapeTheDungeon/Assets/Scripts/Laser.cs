using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    // Update is called once per frame
    
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        //set laser boundaries after
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }    
    }
}
