using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;

    public int health 
    {
        get { return Health; }
        set 
        {
            Health = value;
            if (healthChange != null)
                healthChange();
            if (Health <= 0 && onZeroHealth != null) 
                onZeroHealth();
        }
    }

    [SerializeField]
    private int Health;

    public delegate void OnHealthChange();
    public OnHealthChange healthChange;

    public delegate void OnZeroHealth();
    public event OnZeroHealth onZeroHealth;

    public delegate void OnMaxHealthChange();
    public event OnMaxHealthChange maxHealthChange;

    private void Awake()
    {
        health = maxHealth;

    }
}
