using UnityEngine;

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

    private void Start()
    {
        PhaseAnimator = GetComponent<Animator>();
        //Fight Starts with attack phase
        AttackPhase = true;
        DefencePhase = false;

    }

    private void Update()
    {
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
    public void SetGameAttackPhase()
    {
        AttackPhase = true;
        DefencePhase = false;
    }
    public void SetGameDefencePhase()
    {
        DefencePhase = true;
        AttackPhase = false;
    }
}
