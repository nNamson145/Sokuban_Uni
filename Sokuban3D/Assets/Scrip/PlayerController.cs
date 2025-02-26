using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool allowMove = true;

    public bool isMoving = false;

    public bool isPushing  = false;

    public float moveSpeed = 3f;

    public Vector3 targetposition;

    public LayerMask BlockingLayer;

    [SerializeField]
    private AnimationManager animManager;

    public static PlayerController instance;

    GameManager gameManager = GameManager.Instance;

    //Singleton
    private void Awake()
    {
        if (instance == null)
        {
           instance = this;
           
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        //animManager = GetComponent<AnimationManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) return;
        
        var movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W) && allowMove) movement = Vector3.forward; 
        if (Input.GetKey(KeyCode.S) && allowMove) movement = Vector3.back;
        if (Input.GetKey(KeyCode.D) && allowMove) movement = Vector3.right;
        if (Input.GetKey(KeyCode.A) && allowMove) movement = Vector3.left;

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);

            TryToMove(movement);
        }
        else
        {
            animManager.PlayerMoving(false); //

            animManager.PlayerPushing(false); //
        }
        

    }

    public void TryToMove(Vector3 direction)
    {
        targetposition = transform.position + direction;
        if (!Physics.Raycast(transform.position, direction, out RaycastHit hit, 1f, BlockingLayer))
        {
            StartCoroutine(MoveToPosition(targetposition));

            animManager.PlayerMoving(true); //

            animManager.PlayerPushing(false); //

            isPushing = false;


        }
        else if (hit.collider.CompareTag("Box"))
        {
            var box = hit.collider.GetComponent<BoxController>();
            if (box != null && box.TryToPush(direction,moveSpeed))
            {
                StartCoroutine(MoveToPosition(targetposition));

                animManager.PlayerMoving(false); //

                animManager.PlayerPushing(true); //
            }

            isPushing = true;
        }
    }

    public IEnumerator MoveToPosition(Vector3 target)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, target) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
           
            yield return null;

        }

        transform.position = target;
        isMoving = false;

    }

    public IEnumerator DelayedCoroutine()
    {
        transform.position = new Vector3(100, 0.5f, 100);
        if (GameManager.Instance.indexlevel == GameManager.Instance.levelList.Count)
        {
            StopAllCoroutines();
            
        }
        else
        {
            yield return new WaitForSeconds(3f);

            transform.position = new Vector3(0, 0.5f, 0);

            allowMove = true;
        }
    }

}
