using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class ProjectileEnemy : Projectile

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
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
