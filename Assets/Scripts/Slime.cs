using System.Collections;
using UnityEngine;

public class Bat : Enemy
{
    public Animator animator;
    

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        PhaseScript.DefencePhaseStarted.AddListener(JumpAttack);
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
        if (isAttacking)
        {
            animator.SetBool("isAttacking", true);
        }
        if (!isAttacking)
        {
            animator.SetBool("isAttacking", false);
        }
    }
   
}
