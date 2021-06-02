using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject laserPrefab;

    public Animator animatora;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            animatora.SetBool("isAttacking", true);
        }
    }

    void Shoot()
    {
        Instantiate(laserPrefab, FirePoint.position, FirePoint.rotation);
    }
}
