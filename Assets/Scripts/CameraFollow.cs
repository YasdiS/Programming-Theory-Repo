using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private Vector3 offset = new Vector3(0, 12, -13);

    void Update()
    {
        transform.position = Player.transform.position + offset;
    }
}