using System.Collections;
using UnityEngine;


public class MainHeroScript : MonoBehaviour
{
    public Transform EnemyPosition;

    public PhaseScript GamePhase;
    public GameObject MainHero;
    public Animator animator;
    private bool isAttacking = false;


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

        //EnemySpawner.SetEnemyUnderAttack(true, Damage);
        GameObject.FindGameObjectWithTag("EnemyUnit").GetComponent<Enemy>().SetEnemyUnderAttack(true, Damage);
        return Damage;
    }

    private IEnumerator AttackHandler()
    {
        Vector3 DefaultPosition = MainHero.transform.position;

        JumpAttack();

        yield return new WaitForSeconds(1);

        MainHero.transform.position = DefaultPosition;

        animator.SetBool("isAttacking", false);
        animator.Play("IDLE");
        GameObject.FindGameObjectWithTag("EnemyUnit").GetComponent<Enemy>().SetEnemyUnderAttack(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(AttackHandler());
            animator.SetBool("isAttacking", false);
            isAttacking = false;
        }
        /*&& !isAttacking
        && enemyscript.GetIsDead()
        && !GamePhase.GetGameAttackPhase())*/
    }
}
