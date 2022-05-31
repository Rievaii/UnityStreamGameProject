using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bat : Enemy
{
    public Animator animator;
    public bool isAttacking = false;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().GamePhaseChanged.AddListener(JumpAttack);
        //GameObject.FindGameObjectWithTag("GamePhase").GetComponent<PhaseScript>().GamePhaseChanged.AddListener(PlayAttackAnimation);
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
    void PlayAttackAnimation()
    {
        animator.SetBool("isAttacking", true);
        //has no stop animation
    }
}
