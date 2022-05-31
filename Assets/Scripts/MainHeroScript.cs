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
    private bool isAttacking = false;
    private int AttackCounter = 0;


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

    private IEnumerator AttackHandler()
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
   
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) 
        && !isAttacking
        && phaseScript.GetGameAttackPhase())
        {
            StartCoroutine(AttackHandler());
            animator.SetBool("isAttacking", false);
            phaseScript.PhaseCounter(AttackCounter);
            if (AttackCounter > 2)
            {
                AttackCounter = 0;
            }
            else
            {
                AttackCounter++;
                Debug.Log(AttackCounter);
            }
            isAttacking = false;
        }
        
    }
}
