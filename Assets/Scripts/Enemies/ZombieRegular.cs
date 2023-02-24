using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieRegular : Enemy
{
    void Update()
    {
        FollowPlayer();
        LookAtPlayer();
    }

    public override void FollowPlayer()
    {
        distanceEnemy = 2.0f;
        base.FollowPlayer();
    }
}
