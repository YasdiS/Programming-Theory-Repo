using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : Projectile

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
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
