using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    public float gridSize = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            Vector3 possition = transform.position;

            possition.x = Mathf.Round(possition.x / gridSize) * gridSize;
            possition.y = Mathf.Round(possition.y / gridSize) * gridSize;
            possition.z = Mathf.Round(possition.z / gridSize) * gridSize;

            transform.position = possition;
        }
    }
}
