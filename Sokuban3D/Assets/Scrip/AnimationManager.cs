using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    const string STR_IS_MOVING = "isMoving";
    const string STR_IS_PUSHING = "isPushing";

    Animator animatorController;



    private void Start()
    {
        animatorController = GetComponentInChildren<Animator>();
    }

    public void PlayerMoving(bool bMove)
    {
        animatorController.SetBool(STR_IS_MOVING, bMove);
    }

    public void PlayerPushing(bool bPush)
    {
        animatorController.SetBool(STR_IS_PUSHING, bPush);
    }
}
