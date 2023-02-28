using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 100.0f;
    [SerializeField] GameObject projectilePrefab;
    
    private GameObject focalPoint;
    private Rigidbody playerRb;
    private Vector3 lookPos;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        //ABSTRACTION
        MovementPlayer();
        MovementAim();
        ShootingProjectile();
    }

    //ABSTRACTION
    void MovementPlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.velocity = focalPoint.transform.TransformVector(horizontalInput, 0, verticalInput) * speed;
    }

    //ABSTRACTION
    void MovementAim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
    }

    //ABSTRACTION
    void ShootingProjectile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
