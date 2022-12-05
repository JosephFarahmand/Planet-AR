using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMenu : MonoBehaviour
{
    public Animator animator;
    public string showBool = "IsShow";

    public void ChangeState()
    {
        var isShow = animator.GetBool(showBool);
        animator.SetBool(showBool, !isShow);
    }
}
