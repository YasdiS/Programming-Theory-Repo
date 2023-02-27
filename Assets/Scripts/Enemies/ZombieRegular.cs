using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieRegular : Enemy
{
    private UnitHealth regularHealth = new UnitHealth(100, 100);
    
    void Update()
    {
        FollowPlayer();
        LookAtPlayer();
    }

    protected override void FollowPlayer()
    {
        distanceEnemy = 0.0f;
        base.FollowPlayer();
    }

    private void EnemyTakeDamage(int damage)
    {
        regularHealth.DamageUnit(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile_Player"))
        {
            EnemyTakeDamage(50);
            Debug.Log("Enemy Regular get hit: " + regularHealth.Health);
        }

        if (regularHealth.Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
