using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaAtNow : MonoBehaviour
{
    public GameObject sofaAtPast;
    Transform myTransform;
    Vector3 selfScenePosition;

    void Awake()
    {
        myTransform = transform;
        //将自身坐标转换为屏幕坐标
        selfScenePosition = Camera.main.WorldToScreenPoint(myTransform.position); 
        print("scenePosition:" + selfScenePosition);
    }
    
    void OnMouseDrag() //鼠标拖拽时系统自动调用该方法
    {
        //获取拖拽点鼠标坐标
        //print("x "+Input.mousePosition.x + " y " + Input.mousePosition.y + " z " + Input.mousePosition.z);
        //新的屏幕点坐标
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
        //将屏幕坐标转换为世界坐标
        Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition); 
        //设置对象位置为鼠标的世界位置
        myTransform.position = currentWorldPosition;
        
        if (myTransform.position.x > 1.0f)
        {
            gameObject.SetActive(false);
            sofaAtPast.transform.position = myTransform.position;
            sofaAtPast.SetActive(true);
        }
    }

}
