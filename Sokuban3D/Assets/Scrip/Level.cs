using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<BoxController> boxList;

    public List<GameObject> goalList;

    public LevelData levelData;

    public GameObject TheDoor;

    // Start is called before the first frame update
    void Start()
    {
        TheDoor.GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTheDoor()
    {
        TheDoor.GetComponent<Door>().SetLayerMark(true);
    }
}
