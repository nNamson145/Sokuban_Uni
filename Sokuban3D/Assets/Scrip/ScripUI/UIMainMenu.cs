using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart()
    {
        UIManager.Instance.OnGameStart();
    }
    public void OnClickLevel()
    {

    }
    public void OnClickQuit()
    {

    }
}
