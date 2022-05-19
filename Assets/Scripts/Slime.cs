using System.Collections;
using UnityEngine;

public class Bat : Enemy
{
    public Animator animator;

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
        if (!GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().GetGameAttackPhase())
        {
            animator.SetBool("isAttacking", true);
            JumpAttack(DiceRoll(1,3,2));
            animator.SetBool("isAttacking", false);
            

        }
    }
}
