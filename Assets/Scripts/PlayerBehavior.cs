using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHealing(50);
            Debug.Log("Player get healing: " + GameManager.Instance.playerHealth.Health);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie_1_Regular"))
        {
            PlayerTakeDamage(10);
            Debug.Log("Player get damage from Regular: " + GameManager.Instance.playerHealth.Health);
        }
        else if (collision.gameObject.CompareTag("Projectile_Enemy"))
        {
            PlayerTakeDamage(5);
            Debug.Log("Player get damage from Regular: " + GameManager.Instance.playerHealth.Health);
        }
        else if (collision.gameObject.CompareTag("Zombie_3_Tanker"))
        {
            PlayerTakeDamage(15);
            Debug.Log("Player get damage from Regular: " + GameManager.Instance.playerHealth.Health);
        }
        else if (collision.gameObject.CompareTag("Zombie_4_Boss"))
        {
            PlayerTakeDamage(50);
            Debug.Log("Player get damage from Regular: " + GameManager.Instance.playerHealth.Health);
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
