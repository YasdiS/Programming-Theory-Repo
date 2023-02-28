using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class ProjectilePlayer : Projectile
{
    void Start()
    {
        //ABSTRACTION
        ProjectileRange();
    }

    
    void Update()
    {
        //ABSTRACTION
        ProjectileMovement();
        OutofBounds();
    }

    //POLYMORPHISM
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
