using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject level;

    public int score;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }
}
