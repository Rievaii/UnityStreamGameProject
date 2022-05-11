using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider EnemySlider;
    public Enemy enemyClass;
    public float CurrentHP;

    private void Start()
    {
        EnemySlider.value = 20; 
        
    }
    
    public void EnemyTakeDamage(int DamageAmount)
    {
        EnemySlider.value -= DamageAmount;
    }

    public bool HasNoHP()
    {
        if (EnemySlider.value < 1 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public float GetHP()
    {
        return EnemySlider.value;
    }
}
