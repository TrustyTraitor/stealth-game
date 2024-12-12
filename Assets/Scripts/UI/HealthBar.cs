using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Gradient gradient;
    public Slider slider;
    public HealthComponent hc;

    public Image fill;

    private void Awake()
    {
        slider = GetComponent<Slider>();

        if (hc == null)
        {
            hc = GameObject.FindWithTag("Player").GetComponent<HealthComponent>();
        }

        if (hc != null)
        {
            hc.healthChange += UpdateHealth;
            hc.maxHealthChange += UpdateMaxHealth;

            slider.maxValue = hc.maxHealth;
            slider.value = hc.health;
        }

    }

    private void OnDisable()
    {
        hc.healthChange -= UpdateHealth;
        hc.maxHealthChange -= UpdateMaxHealth;
    }

    public void UpdateHealth()
    {
        slider.value = hc.health;

        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    public void UpdateMaxHealth()
    {
        slider.maxValue = hc.maxHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
