using System.Collections;
using UnityEngine;


public class MainHeroScript : MonoBehaviour
{
    public Transform EnemyPosition;

    public PhaseScript phaseScript;
    public GameObject MainHero;
    public Animator animator;

    [SerializeField]
    private HealthBar MainHeroHealthBar;
    public bool isAttacking = false;
    


    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void JumpAttack()
    {
        MainHero.transform.position = new Vector3(EnemyPosition.transform.position.x - 1.2f, EnemyPosition.transform.position.y - 0.9f, EnemyPosition.transform.position.z);

        animator.SetBool("isAttacking", true);
        animator.Play("AttackAnimation");

        isAttacking = true;

    }

    public int DiceRoll()
    {
        int Damage = Random.Range(4, 8);
        try { GameObject.FindGameObjectWithTag("EnemyUnit").GetComponent<Enemy>().SetEnemyUnderAttack(true, Damage); }
        catch { Debug.Log("Unable to find clone script element"); }
        return Damage;
    }

    public IEnumerator AttackHandler()
    {
        Vector3 DefaultPosition = MainHero.transform.position;

        JumpAttack();

        yield return new WaitForSeconds(1);

        MainHero.transform.position = DefaultPosition;

        animator.SetBool("isAttacking", false);
        animator.Play("IDLE");
        try { GameObject.FindGameObjectWithTag("EnemyUnit").GetComponent<Enemy>().SetEnemyUnderAttack(false); }
        catch { Debug.Log("Unable to find clone script"); }
    }
    public void TakeDamage(int damage)
    {
        MainHeroHealthBar.TakeDamage(damage);
        //play takedamage and death animation
        
    }
}
