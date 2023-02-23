using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoss : Enemy
{
    void Update()
    {
        FollowPlayer();
        LookAtPlayer();
    }

    public override void FollowPlayer()
    {
        distanceEnemy = 5.0f;
        base.FollowPlayer();
    }
}
