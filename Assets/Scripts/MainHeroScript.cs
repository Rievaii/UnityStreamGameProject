using UnityEngine;
using UnityEngine.Events;

public class MainHeroScript : MonoBehaviour
{
    //Main Hero position
    public GameObject MainHero;
    public Vector3 StartPosition;

    //Enemy position
    public Transform EnemyPosition;

    public Animator animator;

    private HealthBar MainHeroHealthBar;
    public UnityEvent DealtDamage = new UnityEvent();


    public void Start()
    {
        animator = GetComponent<Animator>();

        StartPosition = MainHero.transform.position;
    }

    public void AttackHandler()
    {
        MainHero.transform.position = new Vector3(
            EnemyPosition.transform.position.x - 1.2f,
            EnemyPosition.transform.position.y - 0.9f,
            EnemyPosition.transform.position.z
            );

        animator.SetBool("isAttacking", true);
        DealtDamage.Invoke();
    }

    public void ReturnToPosition()
    {
        MainHero.transform.position = StartPosition;
        animator.SetBool("isAttacking", false);
    }

    public void TakeDamage(int damage)
    {
        MainHeroHealthBar.TakeDamage(damage);
        //play takedamage and death animation 
        //subscribe to takedamageevent 

    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AttackHandler();
        }
    }
}
