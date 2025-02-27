using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public GameObject uiMainmenu;
    public GameObject uiInGame;
    public GameObject uiLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameStart()
    {
        uiMainmenu.SetActive(false);
        GameManager.Instance.NewLevel(0);
    }

    public void OnGameQuit()
    {
        GameManager.Instance.OnQuitGame();
    }
}
