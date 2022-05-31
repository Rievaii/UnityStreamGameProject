using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PhaseScript : MonoBehaviour
{
    [SerializeField]
    private bool isAttackPhase;
    [SerializeField]
    private Animator PhaseAnimator;
    [SerializeField]
    private GameObject AttackPhaseImage;
    [SerializeField]
    private GameObject DefencePhaseImage;

    public UnityEvent GamePhaseChanged = new UnityEvent();

    private void Start()
    {
        PhaseAnimator = GetComponent<Animator>();
        isAttackPhase = true;
    }

    public void PhaseCounter(int PhaseHitCounter)
    {
        //hits to change phase
        if (PhaseHitCounter > 2)
        {
            StartCoroutine(ChangePhase());
        }
    }
    public bool GetGameAttackPhase()
    {
        if (isAttackPhase)
        {
            return true;
        }
        if (!isAttackPhase)
        {
            return false;
        }
        return false;
    }

    public IEnumerator ChangePhase()
    {

        if (isAttackPhase)
        {
            yield return new WaitForSeconds(1);
            isAttackPhase = false;
            GamePhaseChanged.Invoke();
        }
        if (!isAttackPhase)
        {
            yield return new WaitForSeconds(1);
            isAttackPhase = true;
            GamePhaseChanged.Invoke();
        }
    }

    void Update(){
        if (isAttackPhase)
        {
            PhaseAnimator.SetBool("AttackPhase", true);
            PhaseAnimator.SetBool("DefencePhase", false);
            DefencePhaseImage.SetActive(false);
            AttackPhaseImage.SetActive(true);
        }

        if (!isAttackPhase)
        {
            PhaseAnimator.SetBool("DefencePhase", true);
            PhaseAnimator.SetBool("AttackPhase", false);
            AttackPhaseImage.SetActive(false);
            DefencePhaseImage.SetActive(true);
        }
    }
}
