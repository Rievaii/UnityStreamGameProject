using UnityEngine;

public class Slime : Enemy
{
    public Animator animator;
    public bool isAttacking = false;

    public int BatDiceRoll(int MinDamage, int MaxDamage)
    {
        int Damage = Random.Range(MinDamage, MaxDamage);
        return Damage;
    }
    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (GetEnemyUnderAttack())
        {
            animator.SetBool("isUnderAttack", true);
        }
        if (GetIsDead())
        {
            animator.SetBool("isDead", true);
        }
        if (!GetEnemyUnderAttack())
        {
            animator.SetBool("isUnderAttack", false);
        }
        if (!GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().GetGameAttackPhase()&& !isAttacking )
        {
            isAttacking = true;
            if (isAttacking)
            {
                animator.SetBool("isAttacking", true);
                StartCoroutine(JumpAttack(BatDiceRoll(1, 3)));
                animator.SetBool("isAttacking", false);
                GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().DefenceCounter++;
                isAttacking = false;
            }
        }
    }
}

