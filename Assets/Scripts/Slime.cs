using System.Collections;
using UnityEngine;

public class Bat : Enemy
{
    public Animator animator;
    public bool isAttacking = false;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public int SlimeDiceRoll(int MinDamage, int MaxDamage)
    {
        int Damage = Random.Range(MinDamage, MaxDamage);
        return Damage;
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
        if (!GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().GetGameAttackPhase() && !isAttacking)
        {
            isAttacking = true;
            if (isAttacking)
            {
                animator.SetBool("isAttacking", true);
                StartCoroutine(JumpAttack(SlimeDiceRoll(1, 3)));
                animator.SetBool("isAttacking", false);
                GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().DefenceCounter++;
                isAttacking = false;
            }
        }
    }
}
