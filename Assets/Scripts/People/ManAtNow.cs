using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAtNow : MonoBehaviour
{
    private Animator animator;
    private static bool hasDiary, hasFlower;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("hasFlower",hasFlower);
    }

    private void ThrowDiary()
    {
        //丢掉日记的动画
        
        //日记进入背包
        
    }
}
