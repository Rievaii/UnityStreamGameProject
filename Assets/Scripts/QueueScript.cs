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
        for (int u = 0; u < 3; u++)
        {
            Debug.Log(TileNames[u]);
        }

        AddEnemyToQueue("Bat",3);
        AddEnemyToQueue("Slime");
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
                    ListElements.Add(Resources.Load<GameObject>(TilePrefabDir + EnemyName));
                }
                for (int e = 0; e < MaxElements; e++)
                {
                    GameObject ListElement = Instantiate(ListElements[e]);
                    ListElement.transform.SetParent(ContentContainer.transform, false);
                    ListElement.name = e.ToString();
                }

            }
        }
        catch (ArgumentException)
        {
            Debug.Log("No such enemy found");
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
            //instantiate a whole list of gameobjects
            ListElements.Add(Resources.Load<GameObject>(TilePrefabDir+EnemyName));
            
            //problem is here
            for (int l = 0; l < MaxElements; l++)
            {
                GameObject ListElement = Instantiate(ListElements[l]);
                ListElement.transform.SetParent(ContentContainer.transform, false);
                ListElement.name = l.ToString();
            }
        }

        /*catch(ArgumentException)
        {
            Debug.Log("No such enemy found");
        }*/
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
    public void RemoveTileFromList()
    {
        try
        {
            if (ListElements.Count > 0)
            {
                //delete function does not work properly
                //Tile to delete
                ListElements.RemoveAt(0);
                //Destroy(TileContainer.chuld[0]);
                
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
            //Debug.Log("No Tiles to delete");
        }
    }
    public int ListElementsCount()
    {
        return ListElements.Count();
    }
}
