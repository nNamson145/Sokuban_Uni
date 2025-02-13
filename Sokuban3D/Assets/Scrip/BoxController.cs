using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public Vector3 targetposition;

    public LayerMask BlockingLayer;

    private bool isMoving;

    public bool onGoal;

    [SerializeField]
    private Toggle checkBox;

    public bool TryToPush(Vector3 direction, float speed)
    {
        targetposition = transform.position + direction;
        if (!Physics.Raycast(transform.position, direction, out RaycastHit hit, 1f, BlockingLayer))
        {
            StartCoroutine(MoveToPosition(targetposition, speed));
            return true;
        }
        return false;
    }

    public IEnumerator MoveToPosition(Vector3 target, float speed)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;

        }

        transform.position = target;
        isMoving = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            onGoal = true;

            checkBox.isOn = onGoal;

            print(other.gameObject);

            GameManager.Instance.CheckWin();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            onGoal = false;

            checkBox.isOn = onGoal;

        }
    }
}
