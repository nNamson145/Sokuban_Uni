using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Level> levelList;

    public Level currrentLevel;

    public int indexlevel;

    public int score;


    //Singleton
    private void OnEnable()
    {
        Instance = this;
        NewLevel(indexlevel);
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void NewLevel(int index)
    {
        if (index >= 0 && index < levelList.Count)
        {
            currrentLevel = levelList[index];
        }

        if (currrentLevel != null)
        {
            currrentLevel.gameObject.SetActive(true);
            Debug.Log(currrentLevel.name);
        }
        else
        {
            Debug.Log("CurrentLevel is null!!");
        }

        
    }

    public void CheckWin()
    {
        score = 0;
        foreach (BoxController box in currrentLevel.boxList)
        {
            
            if (box.onGoal)
            {
                score++;
            }
        }

        if (score == currrentLevel.goalList.Count)
        {

            Debug.Log("Level Compelete !");
            currrentLevel.OpenTheDoor();
            indexlevel++;
            //NewLevel(indexlevel);

        }
    }
}
