using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PhaseScript : MonoBehaviour
{
    public MainHeroScript mainHeroScript;
    [SerializeField]
    private GameObject AttackPhaseImage;
    [SerializeField]
    private GameObject DefencePhaseImage;
    [SerializeField]
    private Animator PhaseAnimator;


    public float TimeBetweenEnemyAttacks = 1.2f;
    public int PhaseActions = 0;

    public enum GamePhase { AttackPhase, DefencePhase };

    private GamePhase CurrentPhase = GamePhase.AttackPhase;
    
    
    public void Update()
    {
        if(CurrentPhase == GamePhase.AttackPhase)
        {
            PhaseAnimator.SetBool("AttackPhase", false);
            if (Input.GetKeyDown(KeyCode.Space)
            && mainHeroScript.isAttacking == false)
            {
                StartCoroutine(mainHeroScript.AttackHandler());
                mainHeroScript.animator.SetBool("isAttacking", false);
            }
        }
    }
    /*
     * PhaseAnimator.SetBool("DefencePhase", true);
     * PhaseAnimator.SetBool("AttackPhase", false);
     */
}
