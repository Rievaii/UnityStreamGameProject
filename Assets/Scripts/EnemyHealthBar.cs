using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider EnemySlider;
    public Enemy enemyClass;

    private void Start()
    {
        EnemySlider.value = 20; 
        
    }
    
    public void EnemyTakeDamage(int DamageAmount)
    {
        EnemySlider.value -= DamageAmount;
    }

    private void Update()
    {
        if (EnemySlider.value <= 0)
        {
            enemyClass.SetEnemyDead(true);
        }
    }
}
