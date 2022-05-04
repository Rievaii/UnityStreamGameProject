using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(int HealthAmount)
    {
        slider.value = HealthAmount;    
    }


    public float GetHealth()
    {
        return slider.value; 
    }



    public void TakeDamage(int Damage)
    {
        slider.value -= Damage;
    }
    private void Start()
    {
        SetHealth(20);
    }
}
