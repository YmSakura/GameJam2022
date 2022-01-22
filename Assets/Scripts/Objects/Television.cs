using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour
{
    public Woman woman;
    private Animator animator;
    private bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        animator.SetBool("isOpen", isOpen);
    }
    
    //鼠标点击->女进门->判断是否有结婚照->
    private void OnMouseDown()
    {
        //切换电视机状态
        isOpen = true;
        //女主进门
        woman.EnterRoom();
    }

    //关闭电视机
    public void SwitchStatus()
    {
        isOpen = false;
    }
    
    
}
