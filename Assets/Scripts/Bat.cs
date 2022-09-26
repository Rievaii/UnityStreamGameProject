using UnityEngine;

public class Slime : Enemy
{
    public Animator animator;
    
    //slime

    public int BatDiceRoll(int MinDamage, int MaxDamage)
    {
        int Damage = Random.Range(MinDamage, MaxDamage);
        return Damage;
    }
    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        PhaseScript.DefencePhaseStarted.AddListener(JumpAttack);
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

