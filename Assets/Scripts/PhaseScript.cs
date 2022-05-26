using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PhaseScript : MonoBehaviour
{
    [SerializeField]
    private bool AttackPhase = false;
    [SerializeField]
    private bool DefencePhase = false;
    public Animator PhaseAnimator;
    [SerializeField]
    private GameObject AttackPhaseImage;
    [SerializeField]
    private GameObject DefencePhaseImage;

    public UnityEvent DefencePhaseStarted;
    public UnityEvent AttackPhaseStarted;

    public int AttackHitCounter;
    public int DefenceHitCounter;

    public void Start()
    {
        PhaseAnimator = GetComponent<Animator>();
        AttackPhase = true;
        DefencePhase = false;
        AttackHitCounter = 0;
        DefenceHitCounter = 0;

    }


    public void Update()
    {
        if (AttackHitCounter > 2)
        {
            StartCoroutine(SetGameDefencePhase());
            AttackHitCounter = 0;
            AttackPhaseStarted.Invoke();
            
        } 
        if(DefenceHitCounter > 2)
        {
            StartCoroutine(SetGameAttackPhase());
            DefenceHitCounter = 0;
            DefencePhaseStarted.Invoke();
        }
        if (AttackPhase)
        {
            DefencePhase = false;
            PhaseAnimator.SetBool("AttackPhase", true);
            PhaseAnimator.SetBool("DefencePhase", false);
            DefencePhaseImage.SetActive(false);
            AttackPhaseImage.SetActive(true);
        }

        if (DefencePhase)
        {
            AttackPhase = false;
            PhaseAnimator.SetBool("DefencePhase", true);
            PhaseAnimator.SetBool("AttackPhase", false);
            AttackPhaseImage.SetActive(false);
            DefencePhaseImage.SetActive(true);
        }

        if (!AttackPhase && !DefencePhase)
        {
            Debug.Log("No game phase choosen!");
        }

        if (AttackPhase && DefencePhase)
        {
            Debug.Log("Both game phases are chosen at once!");
            return;
        }
    }

    public bool GetGameAttackPhase()
    {
        if (AttackPhase)
        {
            return true;
        }
        else if (DefencePhase)
        {
            return false;
        }
        return false;
    }
    public IEnumerator SetGameAttackPhase()
    {
        yield return new WaitForSeconds(2f);
        AttackPhase = true;
        DefencePhase = false;

    }
    public IEnumerator SetGameDefencePhase()
    {
        yield return new WaitForSeconds(4f);
        DefencePhase = true;
        AttackPhase = false;
    }
}
