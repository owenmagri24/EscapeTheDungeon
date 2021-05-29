﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BuddyGraphics : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f){
            transform.localScale = new Vector3(-0.75f, 0.75f, 0.75f);
        } else if(aiPath.desiredVelocity.x >= -0.01f){
            transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
    }
}
