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
    public Inventory inventory;
    public Item Frame, Diary;

    private void Update()
    {
        anim.SetBool("isLeave", isLeave);
        anim.SetBool("isIn", isIn);
        anim.SetBool("isFrameFull", isFrameFull);
        anim.SetBool("hasDiary", hasDiary);

        if (inventory.itemList.Contains(Frame))
            isFrameFull = true;
        if (inventory.itemList.Contains(Diary))
            hasDiary = true;

    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    
    //由Door调用，门开后进入
    public void EnterRoom()
    {
        Debug.Log("进入房间");
        //进入房间的动画
        isIn = true;
        
        if (isFrameFull)
        {
            Debug.Log("看到了完整的结婚照");
        }
        else
        {
            //如果没有看到则延时离开房间
            StartCoroutine(Timer());
        }
    }

    //协程计时器
    IEnumerator Timer()
    {
        Debug.Log("停留房间");
        yield return new WaitForSeconds(10f);
        Moveout();
    }

    void Moveout()
    {
        Debug.Log("离开房间");
        //离开房间的动画
        isLeave = true;
    }
    

    //取消进入状态，在moveIn动画中调用
    void StayAtRoom()
    {
        isIn = false;
    }
    
    //关门，在moveOut动画结束时调用
    void ExitRoom()
    {
        gameObject.SetActive(false);
        //关门
        door.isOpen = false;
        //电视机状态切换
        television.SwitchStatus();
        isLeave = false;
    }
}