using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemycanvas;
    public EnemyHealthBar enemyhealthbar;
    public GameObject MainHero;

    [SerializeField]
    private bool isDead;
    private bool EnemyUnderAttack = false;
    public bool DamageDealt = false;
    private bool isAttacked = false;
    [SerializeField]
    private int HitCounter = 0; 

    public void SetEnemyUnderAttack(bool EnemyUnderAttack, int Damage)
    {
        this.EnemyUnderAttack = EnemyUnderAttack;
        enemyhealthbar.EnemyTakeDamage(Damage);
    }
    public void SetEnemyUnderAttack(bool EnemyUnderAttack)
    {
        this.EnemyUnderAttack = EnemyUnderAttack;
    }

    public bool GetEnemyUnderAttack()
    {
        return EnemyUnderAttack;
    }
    public float GetHP()
    {
        return enemyhealthbar.EnemySlider.value;
    }

    public bool GetIsDead()
    {
        if (enemyhealthbar.HasNoHP())
        {
            isDead = true;
            return isDead;
        }
        else
        {
            isDead = false;
            return isDead;
        }
    }

    public void EnemyJumpAttack()
    {
        isAttacked = false;
        if (!isAttacked)
        {
            Vector3 DefaultPosition = this.transform.position;


            this.transform.position = new Vector3(MainHero.transform.position.x + 1.2f, MainHero.transform.position.y + 0.9f, MainHero.transform.position.z);

            GameObject.FindGameObjectWithTag("MainHero").GetComponent<MainHeroScript>().TakeDamage(3);
            GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().PhaseCounter(HitCounter);
            
            if (HitCounter > 2)
            {
                HitCounter = 0;
            }
            else
            {

                HitCounter++;
                Debug.Log(HitCounter);
            }
            this.transform.position = DefaultPosition;
            isAttacked = true;
        }

        
    }
    
}
