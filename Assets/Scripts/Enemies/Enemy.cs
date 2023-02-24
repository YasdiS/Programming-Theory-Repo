using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 5.0f;

    protected Rigidbody enemyRb;
    protected GameObject player;
    
    protected float distance;
    protected float distanceEnemy;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    //Enemy Follow The Player
    public virtual void FollowPlayer()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        
        if ( distance > distanceEnemy)
        {
            enemyRb.velocity = transform.forward * speed;
        } else
        {
            enemyRb.velocity = transform.forward * 0;
        }
        
    }

    //Enemy Look at Player
    public void LookAtPlayer()
    {
        Vector3 lookVector = player.transform.position - transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
    }
}
