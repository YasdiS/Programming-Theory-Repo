using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

//INHERITANCE FROM CLASS ENEMY
public class ZombieShooter : Enemy
{
    [SerializeField] GameObject projectileEnemy;

    private float timer;
    private UnitHealth shooterHealth = new UnitHealth(100, 100);

    void Update()
    {
        //ABSTRACTION
        FollowPlayer();
        LookAtPlayer();
    }

    //POLYMORPHISM
    protected override void FollowPlayer()
    {
        distanceEnemy = 15.0f;
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > distanceEnemy)
        {
            enemyRb.velocity = transform.forward * speed;
        }
        else
        {
            enemyRb.velocity = transform.forward * 0;
            SpawnProjectileEnemy();
        }
    }

    private void SpawnProjectileEnemy()
    {
        timer += Time.deltaTime;
        
        if (timer > 2)
        {
            timer = 0;
            Instantiate(projectileEnemy, transform.position, transform.rotation);
        }
    }

    private void EnemyTakeDamage(int damage)
    {
        shooterHealth.DamageUnit(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile_Player"))
        {
            EnemyTakeDamage(50);
            Debug.Log("Enemy shooter get hit: " + shooterHealth.Health);
        }

        if (shooterHealth.Health <= 0)
        {
            Destroy(gameObject);
            mainManager.UpdateScore(pointValue);
        }
    }
}
