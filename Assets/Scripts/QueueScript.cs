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
    private string TilePrefabDir = @"EnemyTiles\";

    public List<GameObject> ListElements = new List<GameObject>();
    public string[] TileNames = new string[] { };

    public void Start()
    {
        string TileNamesPath = @"Assets/Resources/EnemyTiles/";
        TileNames = Directory.GetFiles(TileNamesPath);
     
        AddEnemyToQueue("Bat", 2);
        AddEnemyToQueue("Slime",1);

        DrawElements();

    }

    private void AddEnemyToQueue(string EnemyName, int Times)
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
                ListElements.Add(Resources.Load<GameObject>(TilePrefabDir + EnemyName));
            }
        }
    }

    private void AddEnemyToQueue(string EnemyName)
    {
        foreach (Transform child in ContentContainer.transform)
        {
            Destroy(child.gameObject);
        }

        var MatchInList = TileNames.Where(item => item.Contains(EnemyName)).FirstOrDefault();

        if (MatchInList != null)
        {
            ListElements.Add(Resources.Load<GameObject>(TilePrefabDir + EnemyName));
        }
    }
    private void DrawElements()
    {
        for (int l = 0; l < MaxElements-1; l++)
        {
            GameObject ListElement = Instantiate(ListElements[l]);
            ListElement.transform.SetParent(ContentContainer.transform, false);
            ListElement.name = l.ToString();
        }
    }
    public string GetCurrentQueueElement(int ElementNumber)
    {
        try
        {
            return ListElements[ElementNumber].transform.name;
        }
        catch (ArgumentOutOfRangeException)
        {
            Debug.Log("List of enemies is null");
        }
        return null;
    }
    public void RemoveTileFromList(int ElementNumber)
    {
        try
        {
            if (ListElements.Count > 0)
            {
                ListElements.RemoveAt(ElementNumber);
                Destroy(GetComponent<Transform>().GetChild(0).gameObject);
            }
            else
            {
                Debug.Log("RemoveTileFromList() - TileList in null, no tiles to delete");
                return;
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Debug.Log(ListElementsCount());
        }
    }
    public int ListElementsCount()
    {
        return ListElements.Count();
    }
    
}
