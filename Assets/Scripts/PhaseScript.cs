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

}
