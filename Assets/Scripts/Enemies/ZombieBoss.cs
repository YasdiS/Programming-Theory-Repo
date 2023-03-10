using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//INHERITANCE FROM CLASS ENEMY
public class ZombieBoss : Enemy
{
    private UnitHealth bossHealth = new UnitHealth(1000, 1000);

    void Update()
    {
        //ABSTRACTION
        FollowPlayer();
        LookAtPlayer();
        SpawnBossInterval();
    }

    //POLYMORPHISM
    protected override void FollowPlayer()
    {
        distanceEnemy = 0.0f;
        base.FollowPlayer();
    }

    private void EnemyTakeDamage(int damage)
    {
        bossHealth.DamageUnit(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile_Player"))
        {
            EnemyTakeDamage(50);
            Debug.Log("Enemy Boss get hit: " + bossHealth.Health);
        }

        if (bossHealth.Health <= 0)
        {
            Destroy(gameObject);
            mainManager.UpdateScore(pointValue);
        }
    }
}
