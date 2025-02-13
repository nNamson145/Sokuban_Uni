using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<BoxController> boxList;

    public List<GameObject> goalList;

    public LevelData levelData;


    // Start is called before the first frame update
    void Start()
    {
        /*foreach (BoxController box in boxList)
        {
            Debug.Log(box);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
