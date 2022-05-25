using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    public GameObject enemycanvas;
    public EnemyHealthBar enemyhealthbar;
    public GameObject MainHeroPosition;
    
    
    [SerializeField]
    private bool isDead;
    private bool EnemyUnderAttack = false;
    
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
            isDead=false;   
            return isDead;
        }
    }

    public IEnumerator JumpAttack(int Damage)
    {
        //problem is in this.position
        Vector3 DefaultPosition = this.transform.position;
        this.transform.position = new Vector3(MainHeroPosition.transform.position.x - 1.2f, MainHeroPosition.transform.position.y - 0.9f, MainHeroPosition.transform.position.z);
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("MainHero").GetComponent<MainHeroScript>().TakeDamage(Damage);
        GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().DefenceCounter++;
        this.transform.position = DefaultPosition;
    }
}
