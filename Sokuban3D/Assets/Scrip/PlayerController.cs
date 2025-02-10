using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isMoving = false;

    public bool isPushing  = false;

    public float moveSpeed = 3f;

    public Vector3 targetposition;

    public LayerMask BlockingLayer;

    AnimationManager animManager;

    // Start is called before the first frame update
    void Start()
    {
        animManager = GetComponent<AnimationManager>();
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
            transform.rotation = Quaternion.LookRotation(movement);

            TryToMove(movement);

            print(transform.position);
        }

        
    }

    public void TryToMove(Vector3 direction)
    {
        targetposition = transform.position + direction;
        if (!Physics.Raycast(transform.position, direction, out RaycastHit hit, 1f, BlockingLayer))
        {
            StartCoroutine(MoveToPosition(targetposition));

            animManager.PlayerMoving(isMoving);

            isPushing = false;



        }
        else if (hit.collider.CompareTag("Box"))
        {
            var box = hit.collider.GetComponent<BoxController>();
            if (box != null && box.TryToPush(direction,moveSpeed))
            {
                StartCoroutine(MoveToPosition(targetposition));

                animManager.PlayerMoving(isMoving);

            }

            isPushing = true;
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
