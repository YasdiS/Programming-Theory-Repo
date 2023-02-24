using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieShooter : Enemy
{
    [SerializeField] GameObject projectileEnemy;
    
    void Update()
    {
        FollowPlayer();
        LookAtPlayer();
    }

    public override void FollowPlayer()
    {
        distanceEnemy = 10.0f;
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > distanceEnemy)
        {
            enemyRb.velocity = transform.forward * speed;
        }
        else
        {
            enemyRb.velocity = transform.forward * 0;
            Instantiate(projectileEnemy, transform.position, transform.rotation);
        }
    }
}
