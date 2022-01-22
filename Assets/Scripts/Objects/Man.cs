using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    private bool hasDiary, isInPast, hasFlower;

    private void Update()
    {
        //如果回到过去
        if (isInPast)
        {
            //手上空无一物的动画

            //如果收集到了花
            if (hasFlower)
            {
                //手上拿花的动画
                
            }
        }
        else
        {
            //看手机的动画
            
        }
    }

    private void ThrowDiary()
    {
        //丢掉日记的动画
        
        //日记进入背包
        
    }
}
