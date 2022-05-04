using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    public GameObject SlimePrefab;
    public QueueScript queueScript;
    public Enemy enemyScript;
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
    private void Update()
    {
        CurrentEnemy = queueScript.GetCurrentQueueElement();
        if (CurrentEnemy != null && !isEnemyOnField)
        {

            var instance = Instantiate(SlimePrefab) as GameObject;
            
            instance.transform.SetParent(EnemyCanvas);

            Debug.Log(EnemyDir + CurrentEnemy);
            isEnemyOnField = true;
        }
    }
}
