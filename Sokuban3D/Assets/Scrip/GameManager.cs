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

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void NewLevel()
    {
        if (indexlevel >= 0 && indexlevel < levelList.Count)
        {
            currrentLevel = levelList[indexlevel];
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



            indexlevel++;
        }

    }
}
