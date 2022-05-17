using System;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    public GameObject SlimePrefab;
    public QueueScript queueScript;
    public Transform EnemyCanvas;
    [SerializeField]
    private string CurrentEnemy;



    private int ElementNumber = 0;
    private bool isEnemyOnField = false;


    private void Start()
    {
        foreach (Transform child in EnemyCanvas.transform)
        {
            Destroy(child.gameObject);
        }

        Debug.Log("Element Number " + ElementNumber);
    }
    public void SpawnAnEnemy(string EnemyName)
    {

        try
        {
            if (CurrentEnemy != null)
            {

                var instance = Instantiate(Resources.Load<GameObject>(CurrentEnemy)) as GameObject;

                instance.transform.SetParent(EnemyCanvas);
            }
            else
            {
                Debug.Log("'CurrentEnemy' is null");
            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("No such enemy found");
        }
    }

    public void Update()
    {

        try { CurrentEnemy = queueScript.GetCurrentQueueElement(ElementNumber); }
        catch (ArgumentException) { Debug.Log("Unable to get QueueElement"); }


        if (CurrentEnemy != null && !isEnemyOnField)
        {
            SpawnAnEnemy(CurrentEnemy);
            isEnemyOnField = true;
        }
        try
        {
            if (GameObject.FindGameObjectWithTag("EnemyUnit").GetComponent<Enemy>().GetIsDead())
            {
                foreach (Transform child in EnemyCanvas.transform)
                {
                    Destroy(child.gameObject, 2f);
                }

            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("Old Element Number remooved " + ElementNumber + " in queue script "+ queueScript.GetCurrentQueueElement(ElementNumber));
            queueScript.RemoveTileFromList();
            if(queueScript.ListElementsCount() == 0)
            {
                Debug.Log("No more tiles left in ListElements");
            }
            else if(ElementNumber < queueScript.ListElementsCount())
            {
                ElementNumber++;
            }
            
            Debug.Log("New/Current Element Number " + ElementNumber + " in queue script " + queueScript.GetCurrentQueueElement(ElementNumber));
            isEnemyOnField = false;
        }
    }
}
