using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour
{
    public Woman woman;
    private Animator animator;
    public Door door;
    private bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        animator.SetBool("isOpen", isOpen);
    }
    
    private void OnMouseDown()
    {
        //切换电视机状态
        isOpen = true;
        door.isOpen = true;
    }

    //关闭电视机
    public void SwitchStatus()
    {
        isOpen = false;
    }
    
    
}
