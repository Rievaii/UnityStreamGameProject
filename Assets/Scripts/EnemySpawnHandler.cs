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
        Debug.Log(CurrentEnemy);
        foreach (Transform child in EnemyCanvas.transform)
        {
            Destroy(child.gameObject);
        }

    }
    public void SpawnAnEnemy(string EnemyName)
    {

        try
        {
            var instance = Instantiate(Resources.Load<GameObject>(CurrentEnemy)) as GameObject;

            instance.transform.SetParent(EnemyCanvas);
        }
        catch (NullReferenceException)
        {
            Debug.Log("No such enemy found");
        }
    }

    public void Update()
    {
        //working with slime
        try { CurrentEnemy = queueScript.GetCurrentQueueElement(ElementNumber); }
        catch (ArgumentException) { Debug.Log("No such enemy found"); }
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
            isEnemyOnField = false;
            queueScript.RemoveTileFromList(ElementNumber); 
            ElementNumber++;
        }
    }
}
