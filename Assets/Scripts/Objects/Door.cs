using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    public Woman woman;
    public bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        animator.SetBool("isOpen",isOpen);
    }
    
    void IntoRoom()
    {
        woman.gameObject.SetActive(true);
        //女主进门
        woman.EnterRoom();
    }
}
