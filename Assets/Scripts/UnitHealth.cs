using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    private int currentHealth;
    private int currentMaxHealth;

    public int Health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get 
        { 
            return currentMaxHealth; 
        }
        set 
        { 
            currentMaxHealth = value; 
        }
    }

    public UnitHealth (int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    public void DamageUnit(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void HealUnit(int HealAmount)
    {
        if (currentHealth < currentMaxHealth)
        {
            currentHealth += HealAmount;
        }
        else if ( currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
    }
}
