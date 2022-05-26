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

    public IEnumerator JumpAttack(int Damage)
    {
        Vector3 DefaultPosition = this.transform.position;

        yield return new WaitForSeconds(2);
        this.transform.position = new Vector3(MainHero.transform.position.x + 1.2f, MainHero.transform.position.y + 0.9f, MainHero.transform.position.z);
        
        GameObject.FindGameObjectWithTag("MainHero").GetComponent<MainHeroScript>().TakeDamage(Damage);
        GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().DefenceHitCounter++;

        yield return new WaitForSeconds(2);
        this.transform.position = DefaultPosition;
    }
    public void GetEnemyIsAttacking()
    {
        
    }
}
