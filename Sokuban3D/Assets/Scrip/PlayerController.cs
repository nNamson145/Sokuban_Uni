using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isMoving = false;

    public float moveSpeed = 5f;

    public Vector3 targetposition;

    public LayerMask BlockingLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) return;
        
        var movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) movement = Vector3.forward;
        if (Input.GetKey(KeyCode.S)) movement = Vector3.back;
        if (Input.GetKey(KeyCode.D)) movement = Vector3.right;
        if (Input.GetKey(KeyCode.A)) movement = Vector3.left;

        if (movement != Vector3.zero)
        { 
            TryToMove(movement);
        }
    }

    public void TryToMove(Vector3 direction)
    {
        targetposition = transform.position + direction;
        if(!Physics.Raycast(transform.position, direction, out RaycastHit hit, 1f, BlockingLayer))
        {
            StartCoroutine(MoveToPosition(targetposition));
        }
        else if (hit.collider.CompareTag("Box"))
        {

        }
    }

    public IEnumerator MoveToPosition(Vector3 target)
    {
        isMoving = true;

        while(Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;

        }

        transform.position = target;
        isMoving = false;
    }
}
