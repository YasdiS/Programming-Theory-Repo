using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePlayer : Projectile
{
    void Start()
    {
        ProjectileRange();
    }

    
    void Update()
    {
        ProjectileMovement();
        OutofBounds();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie_1_Regular"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Zombie_2_Shooter"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Zombie_3_Tanker"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Zombie_4_Boss"))
        {
            Destroy(gameObject);
        }
    }
}
