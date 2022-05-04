using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy container to anchor
    public GameObject enemycanvas;
    public EnemyHealthBar enemyhealthbar;
    public MainHeroScript mainheroscript;


    private bool EnemyUnderAttack = false;
    private bool isDead = false;
    private void Start()
    {
        mainheroscript = GetComponent<MainHeroScript>();  
    }
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
    public bool GetIsDead()
    {
        if (enemyhealthbar.HasNoHP())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
