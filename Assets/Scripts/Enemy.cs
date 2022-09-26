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
}
