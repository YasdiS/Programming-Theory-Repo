using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//INHERITANCE FROM CLASS ENEMY
public class ZombieRegular : Enemy
{
    private UnitHealth regularHealth = new UnitHealth(100, 100);
    
    void Update()
    {
        //ABSTRACTION
        FollowPlayer();
        LookAtPlayer();
    }

    //POLYMORPHISM
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
            mainManager.UpdateScore(pointValue);
        }
    }
}
