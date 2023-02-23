using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 40.0f;

    //Range position of projectile
    private float posX;
    private float posMinusX;
    private float posZ;
    private float posMinusZ;

    void Start()
    {
        posX = transform.position.x + 20.0f;
        posMinusX = transform.position.x - 20.0f;
        posZ = transform.position.z + 20.0f;
        posMinusZ = transform.position.z - 20.0f;
    }

    void Update()
    {
        //Projectile Movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        OutofBounds();
    }

    //If projectile hit enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    //limit range for projectile
    private void OutofBounds()
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
