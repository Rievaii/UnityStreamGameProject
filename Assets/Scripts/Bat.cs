using UnityEngine;

public class Slime : Enemy
{
    public Animator animator;
    private int DiceRoll()
    {
        int Damage = Random.Range(2, 4);
        return Damage;
    }
    private void Start()
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
            animator.SetBool("isDead",true);
        }
        if (!GetEnemyUnderAttack())
        {
            animator.SetBool("isUnderAttack", false);
        }
        if (!phaseScript.GetGameAttackPhase())
        {
            JumpAttack(DiceRoll());
            animator.SetBool("isAttacking", true);
        }
    }
}

