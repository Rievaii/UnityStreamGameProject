using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemycanvas;
    public EnemyHealthBar enemyhealthbar;
    public GameObject MainHero;

    [SerializeField]
    private bool isDead;
    public bool UnderAttack { get; set; } = false;

    public void SetEnemyUnderAttack()
    {
        UnderAttack = true;
        Debug.Log("Current enemy got 3 damage");
    }

    public float GetHP()
    {
        return enemyhealthbar.EnemySlider.value;
    }

    public bool GetIsDead()
    {
        if (enemyhealthbar.HasNoHP())
        {
            isDead = true;
            return isDead;
        }
        else
        {
            isDead = false;
            return isDead;
        }
    }
}
