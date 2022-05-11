using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class QueueScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ContentContainer;
    [SerializeField]
    private int MaxElements = 3;
    [SerializeField]
    private string CurrentEnemy;
    private string PrefabDir = @"EnemyTiles\";


    public List<GameObject> ListElements = new List<GameObject>();
    public string[] TileNames = new string[] { };

    public void Start()
    {
        string TileNamesPath = @"Assets/Resources/EnemyTiles/";
        TileNames = Directory.GetFiles(TileNamesPath);
        
        AddEnemyToQueue("Slime");
        //non-correctly counted list cause of that?
        CurrentEnemy = ListElements[0].transform.name;
    }
    private void AddEnemyToQueue(string EnemyName, int Times)
    {
        try
        {
            foreach (Transform child in ContentContainer.transform)
            {
                Destroy(child.gameObject);
            }

            var MatchInList = TileNames.Where(item => item.Contains(EnemyName)).FirstOrDefault();
            if (MatchInList != null)
            {
                for (int j = 0; j < Times; j++)
                {
                    ListElements.Add(Resources.Load<GameObject>(PrefabDir + EnemyName));
                }
                for (int i = 0; i < MaxElements; i++)
                {
                    GameObject ListElement = Instantiate(ListElements[i]);
                    ListElement.transform.SetParent(ContentContainer.transform, false);
                    ListElement.name = i.ToString();
                }

            }
        }
        catch(ArgumentException)
        {
            Debug.Log("No such enemy found");
        }
    }

    private void AddEnemyToQueue(string EnemyName)
    {
        try
        {
            foreach (Transform child in ContentContainer.transform)
            {
                Destroy(child.gameObject);
            }

            var MatchInList = TileNames.Where(item => item.Contains(EnemyName)).FirstOrDefault();
            if (MatchInList != null)
            {
                ListElements.Add(Resources.Load<GameObject>(PrefabDir + EnemyName));
                for (int i = 0; i < MaxElements; i++)
                {
                    GameObject ListElement = Instantiate(ListElements[i]);
                    ListElement.transform.SetParent(ContentContainer.transform, false);
                    ListElement.name = i.ToString();
                }

            }
        }
        catch(ArgumentException)
        {
            Debug.Log("No such enemy found");
        }
    }
    public string GetCurrentQueueElement(int ElementNumber)
    {
        try
        {
            return ListElements[ElementNumber].transform.name;
        }
        catch
        {
            Debug.Log("List of enemies is null");
        }
        return null;
    }
    public bool isNull()
    {
        if(ContentContainer.transform.childCount > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void RemoveTileFromList(int TileToDelete)
    {
        ListElements.RemoveAt(TileToDelete);
        Destroy(GameObject.Find(TileToDelete.ToString()));
    }
}
