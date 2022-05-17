using System;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    public GameObject SlimePrefab;
    public QueueScript queueScript;
    public Transform EnemyCanvas;
    [SerializeField]
    private string CurrentEnemy;
    private bool NextEnemyTime;



    private int ElementNumber = 0;
    private bool isEnemyOnField = false;


    private void Start()
    {
        foreach (Transform child in EnemyCanvas.transform)
        {
            Destroy(child.gameObject);
        }
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
    public void NextEnemy()
    {
        Debug.Log("Old Element Number remooved " + ElementNumber + " in queue script " + queueScript.GetCurrentQueueElement(ElementNumber));
        queueScript.RemoveTileFromList(ElementNumber);
        /*
         * ElementNumber = 0; deletes[0] tile 
         * ElementNumber = 1; deletes[1] with name 2 becaues 0 has already gone
         * ElementNumber = 3; deletes unexisting tile and causes an error
         * 
         * it is fixed for deleting tiles by pointing directly to child component 
         * but not fixed with spawning mobs
         * 
         */
        if (queueScript.ListElementsCount() == 0)
        {
            Debug.Log("No more tiles left in ListElements");
        }
        else if (ElementNumber < queueScript.ListElementsCount())
        {
            
        }
        isEnemyOnField = false;
        Debug.Log("New/Current Element Number " + ElementNumber + " in queue script " + queueScript.GetCurrentQueueElement(ElementNumber));
        
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
            NextEnemy();
        }
    }
}
