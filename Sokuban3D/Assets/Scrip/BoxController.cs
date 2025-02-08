using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Vector3 targetposition;

    public LayerMask BlockingLayer;

    public bool isMoving;


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
}
