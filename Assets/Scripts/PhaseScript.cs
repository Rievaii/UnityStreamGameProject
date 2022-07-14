using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PhaseScript : MonoBehaviour
{
    public GameObject MainHero;
    [SerializeField]
    private GameObject AttackPhaseImage;
    [SerializeField]
    private GameObject DefencePhaseImage;

    public float TimeBetweenEnemyAttacks;

    private void Start()
    {
        TimeBetweenEnemyAttacks = 0.2f;
    }


    /*
     * PhaseAnimator.SetBool("DefencePhase", true);
     * PhaseAnimator.SetBool("AttackPhase", false);
     */
}
