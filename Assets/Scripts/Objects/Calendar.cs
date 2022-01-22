using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer; //用于获取material
    public Material _material;              //普通的材质，用于替换

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    //点击之后更改材质为默认材质
    private void OnMouseDown()
    {
        _spriteRenderer.material = _material;
        //触发对话框
    }
}
