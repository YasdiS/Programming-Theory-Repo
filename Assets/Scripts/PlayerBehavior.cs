using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private MainManager mainManager;

    void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHealing(50);
            Debug.Log("Player get healing: " + GameManager.Instance.playerHealth.Health);
        }

        if (GameManager.Instance.playerHealth.Health <= 0)
        {
            gameObject.SetActive(false);
            mainManager.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie_1_Regular"))
        {
            PlayerTakeDamage(10);
            Debug.Log("Player get damage from Regular: " + GameManager.Instance.playerHealth.Health);
        }
        else if (collision.gameObject.CompareTag("Zombie_3_Tanker"))
        {
            PlayerTakeDamage(15);
            Debug.Log("Player get damage from Tanker: " + GameManager.Instance.playerHealth.Health);
        }
        else if (collision.gameObject.CompareTag("Zombie_4_Boss"))
        {
            PlayerTakeDamage(50);
            Debug.Log("Player get damage from Boss: " + GameManager.Instance.playerHealth.Health);
        }

        if (collision.gameObject.CompareTag("Zombie_1_Regular") || collision.gameObject.CompareTag("Zombie_3_Tanker") || collision.gameObject.CompareTag("Zombie_4_Boss"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            Debug.Log("Collided with: " + collision.gameObject.name);

            enemyRb.AddForce(awayFromPlayer * 50.0f, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile_Enemy"))
        {
            PlayerTakeDamage(5);
            Debug.Log("Player get damage from Shooter: " + GameManager.Instance.playerHealth.Health);
        }
    }

    void PlayerTakeDamage(int damage)
    {
        GameManager.Instance.playerHealth.DamageUnit(damage);
    }

    void PlayerHealing(int healing)
    {
        GameManager.Instance.playerHealth.HealUnit(healing);
    }
}
