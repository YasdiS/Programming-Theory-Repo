using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE FROM CLASS ENEMY
public class ZombieTanker : Enemy
{
    private UnitHealth tankerHealth = new UnitHealth(250, 250);
    
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
        tankerHealth.DamageUnit(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile_Player"))
        {
            EnemyTakeDamage(50);
            Debug.Log("Enemy Tanker get hit: " + tankerHealth.Health);
        }

        if (tankerHealth.Health <= 0)
        {
            Destroy(gameObject);
            mainManager.UpdateScore(pointValue);
        }
    }
}
