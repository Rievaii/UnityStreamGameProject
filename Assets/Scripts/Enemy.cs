using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    public GameObject enemycanvas;
    public EnemyHealthBar enemyhealthbar;
    public MainHeroScript mainheroscript;
    public GameObject MainHeroPosition;
    public PhaseScript phaseScript;
    [SerializeField]

    private bool isDead;
    private bool EnemyUnderAttack = false;
    private void Start()
    {
        phaseScript = GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>();
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
    public float GetHP()
    {
        return enemyhealthbar.EnemySlider.value;
    }
    public IEnumerator JumpAttack(int Damage)
    {
        Vector3 DefaultPosition = this.transform.position;
        this.transform.position = new Vector3(MainHeroPosition.transform.position.x - 1.2f, MainHeroPosition.transform.position.y - 0.9f, MainHeroPosition.transform.position.z);
        yield return new WaitForSeconds(1);
        mainheroscript.TakeDamage(Damage);
        this.transform.position = DefaultPosition;
        phaseScript.DefenceCounter++;
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
    
}
