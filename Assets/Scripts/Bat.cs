using System.Collections;
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
    public IEnumerator BlinkToHero()
    {
        yield return new WaitForSeconds(1);
        Vector3 DefaultPosition = this.transform.position;

        yield return new WaitForSeconds(1f);

        animator.SetBool("isAttacking", true);
        this.transform.position = new Vector3(MainHero.transform.position.x + 1.2f, MainHero.transform.position.y + 0.9f, MainHero.transform.position.z);
        //roll damage

        yield return new WaitForSeconds(1f);

        this.transform.position = DefaultPosition;
        animator.SetBool("isAttacking", false);
    }
}

