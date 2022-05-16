using UnityEngine;

public class Slime : Enemy
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (GetEnemyUnderAttack())
        {
            animator.SetBool("isUnderAttack", true);
            animator.Play("SpikedSlime_Hit");
        }
        if (GetIsDead())
        {
            animator.SetTrigger("Death");
        }
        if (!GetEnemyUnderAttack())
        {
            animator.SetBool("isUnderAttack", false);
            animator.Play("SpikedSlime_Idle");
        }
    }
}

