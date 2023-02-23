using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTanker : Enemy
{
    void Update()
    {
        FollowPlayer();
        LookAtPlayer();
    }

    public override void FollowPlayer()
    {
        distanceEnemy = 3.0f;
        base.FollowPlayer();
    }
}
