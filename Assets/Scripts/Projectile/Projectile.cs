using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float speed = 40.0f;

    //Range position of projectile
    protected float posX;
    protected float posMinusX;
    protected float posZ;
    protected float posMinusZ;

    //ABSTRACTION
    protected void ProjectileRange()
    {
        posX = transform.position.x + 20.0f;
        posMinusX = transform.position.x - 20.0f;
        posZ = transform.position.z + 20.0f;
        posMinusZ = transform.position.z - 20.0f;
    }

    //ABSTRACTION
    protected void ProjectileMovement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //If projectile hit enemy
    //POLYMORPHISM
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    //limit range for projectile
    //ABSTRACTION
    protected void OutofBounds()
    {
        if (transform.position.x > posX)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < posMinusX)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > posZ)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < posMinusZ)
        {
            Destroy(gameObject);
        }
    }
}
