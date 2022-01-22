using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman : MonoBehaviour
{
    private bool isFrameFull, hasDiary;    //相框内是否有结婚照
    public Television television;  
    
    public void EnterRoom()
    {
        //进入房间的动画
        
        //判断是否看到结婚照
        if (isFrameFull)
        {
            //望向相框的动画

            if (hasDiary)
            {
                //阅读日记后看向男方
                
            }
        }
        else
        {
            //延时30s离开房间
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
        
        //关闭电视机
        television.SwitchStatus();
    }
    
}