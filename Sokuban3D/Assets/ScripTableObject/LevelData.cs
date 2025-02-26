using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewLevel", menuName = "LevelConfig", order = 1)]
public class LevelData : ScriptableObject
{
    public int ordinalNumber;

    public string levelName;

    public string levelDescription;

    public GameObject prefabLevel;

    public Sprite displayImage;
}
