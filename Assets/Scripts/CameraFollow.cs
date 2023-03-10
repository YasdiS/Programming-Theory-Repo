using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private Vector3 offset = new Vector3(0, -1, 0);

    void Update()
    {
        //camera follow function
        transform.position = Player.transform.position + offset;

        //camera rotate when "Q" and "E" input pressed
        float cameraRotate = Input.GetAxis("Horizontal Camera");
        float rotateSpeed = 90.0f;

        transform.Rotate(Vector3.up,  cameraRotate * rotateSpeed * Time.deltaTime);
    }
}
