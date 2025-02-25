using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorOpen;

    PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        doorOpen =false;
        controller = PlayerController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool SetLayerMark(bool Open)
    {
        if (Open)
        {
            doorOpen = true;
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.layer = 0;
        }
        else
        {
            doorOpen = false;
            
            gameObject.layer = 10;
    
        }
        return doorOpen;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            controller.allowMove = false;
            controller.gameObject.transform.position = new Vector3(0, 0.5f, 0);
            GameManager.Instance.currrentLevel.gameObject.SetActive(false);
            GameManager.Instance.NewLevel(GameManager.Instance.indexlevel);
            controller.StartCoroutine(controller.DelayedCoroutine());
        }
    }

    
}
