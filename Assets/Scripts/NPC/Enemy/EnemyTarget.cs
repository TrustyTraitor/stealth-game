using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(HealthComponent))]
public class EnemyTarget : MonoBehaviour
{

    public HealthComponent hc;

    private void Start()
    {
        hc = GetComponent<HealthComponent>();

        hc.onZeroHealth += OnDeath;
    }

    public void TakeDamage(int damage)
    {
        hc.health -= damage;
        //Debug.Log(hc.health);
    }

    public void OnDeath() 
    {
        Destroy(gameObject);
    }
}
