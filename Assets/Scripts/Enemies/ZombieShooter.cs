using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShooter : Enemy
{
    void Update()
    {
        FollowPlayer();
        LookAtPlayer();
    }

    public override void FollowPlayer()
    {
        distanceEnemy = 10.0f;
        base.FollowPlayer();
    }
}
