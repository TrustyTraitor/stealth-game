using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public PlayerSkills skills;

    [SerializeField]
    private int MaxHealth;
    public int maxHealth { 
        get { return MaxHealth; } 
        set 
        { 
            MaxHealth = value;
            if (maxHealthChange != null) maxHealthChange();
        } 
    }

    public int health 
    {
        get { return Health; }
        set 
        {
            if (value < health)
            {
                Health -= (int)((health - value) * (1.0f - (skills.shieldMod/100.0f)));
            }
            else {
                Health = value;
            }

            if (healthChange != null)
                healthChange();
            if (Health <= 0 && onZeroHealth != null) 
                onZeroHealth();
        }
    }

    [SerializeField]
    protected int Health;

    public delegate void OnHealthChange();
    public OnHealthChange healthChange;

    public delegate void OnZeroHealth();
    public event OnZeroHealth onZeroHealth;

    public delegate void OnMaxHealthChange();
    public event OnMaxHealthChange maxHealthChange;

    private void Start()
    {
        //Debug.Log((1.0f + (skills.healthMod / 100.0f)) * maxHealth);

        maxHealth = (int)((1.0f + (skills.healthMod/100.0f)) * maxHealth);
        health = maxHealth;

    }
}
