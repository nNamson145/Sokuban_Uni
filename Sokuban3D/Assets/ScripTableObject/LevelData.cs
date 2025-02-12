using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewLevel", menuName = "LevelConfig", order = 1)]
public class LevelData : ScriptableObject
{
    public GameObject prefabLevel;

    public string levelName;

    public string levelDescription;
    
    public Sprite displayImage;
}
