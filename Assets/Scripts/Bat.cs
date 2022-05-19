using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    public Animator animator;

    private int DiceRoll()
    {
        int Damage = Random.Range(2, 4);
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
        if (!GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().GetGameAttackPhase())
        {
            animator.SetBool("isAttacking", true);
            JumpAttack(DiceRoll(2, 4, 3));
            animator.SetBool("isAttacking", false);
              
        }
        if(GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().GetGameAttackPhase())
        {
            Debug.Log("GamePhase = Attack")
        }
    }
}

