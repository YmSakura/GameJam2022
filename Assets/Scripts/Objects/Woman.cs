using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman : MonoBehaviour
{
    public static bool isFrameFull, hasDiary;
    private bool isLeave,isIn;
    public Television television;
    public Door door;
    private Animator anim;

    private void Update()
    {
        anim.SetBool("isLeave", isLeave);
        anim.SetBool("isIn", isIn);
        anim.SetBool("isFrameFull", isFrameFull);
        anim.SetBool("hasDiary", hasDiary);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void EnterRoom()
    {
        Debug.Log("女主进门");
        //进入房间的动画
        isIn = true;
        

        //判断是否看到完整的结婚照
        if (isFrameFull)
        {
            
        }
        else
        {
            //如果没有看到延时30s离开房间
            StartCoroutine(Timer());
        }
    }

    //协程计时器
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(30f);
        ExitRoom();
    }

    void ExitRoom()
    {
        //离开房间的动画
        isLeave = true;
        //电视机状态切换
        television.SwitchStatus();
        //关门
        door.isOpen = false;
    }

    void LeaveRoom()
    {
        isIn = false;
    }
}