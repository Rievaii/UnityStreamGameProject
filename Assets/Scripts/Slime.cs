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
        
    }
    public void GetEnemyIsAttacking()
    {

    }
}
