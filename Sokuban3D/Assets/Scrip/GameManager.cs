using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> levels;

    private int currrentLevel = 0;

    public int score;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void CheckWin()
    {
        foreach (var level in levels)
        {
            
        }
        Debug.Log("Level Compelete !");
    }
}
