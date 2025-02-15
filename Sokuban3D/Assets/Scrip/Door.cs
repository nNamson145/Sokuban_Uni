using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        doorOpen =false;
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
        if (other.CompareTag("Door"))
        {
            GameManager.Instance.currrentLevel.gameObject.SetActive(false);
            GameManager.Instance.NewLevel(GameManager.Instance.indexlevel);
            PlayerController.instance.gameObject.transform.position = new Vector3(0, 0.5f, 0);
        }
    }
}
