using System;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    public GameObject SlimePrefab;
    public QueueScript queueScript;
    public Transform EnemyCanvas;
    private string CurrentEnemy;
    private string EnemyDir  = @"\Resources\Enemies\Slime.Prefab";
    

    private bool isEnemyOnField = false;

    private void Start()
    {

        foreach (Transform child in EnemyCanvas.transform)
        {
            Destroy(child.gameObject);
        }

    }    
    public bool CheckEnemyOnField()
    {
        if (isEnemyOnField)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetEnemyOnField(bool FieldState)
    {
        if (FieldState)
        {
            isEnemyOnField = true;
        }
        if (!FieldState)
        {
            isEnemyOnField = false;
        }
    }
    public void Update()
    {
        CurrentEnemy = queueScript.GetCurrentQueueElement();
        if (CurrentEnemy != null && !isEnemyOnField)
        {
            //instantiate from resources
            var instance = Instantiate(SlimePrefab) as GameObject;
            
            instance.transform.SetParent(EnemyCanvas);

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
                //isEnemyOnField = false;
                Debug.Log("enemy is dead");
                //current enemy switch to next one 
                //QueueScript.NextTile();
            }
        }
        catch(NullReferenceException e)
        {
            isEnemyOnField=false;
        }
    }
}
