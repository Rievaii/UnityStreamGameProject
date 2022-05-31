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
        GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().DefencePhaseStarted.AddListener(EnemyJumpAttack);
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
}

