using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite offSprite, onSprite;
    public Woman woman;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //鼠标点击->女进门->判断是否有结婚照->

    private void OnMouseDown()
    {
        //切换电视机状态
        spriteRenderer.sprite = onSprite;
        //女主进门
        woman.EnterRoom();
    }

    public void SwitchStatus()
    {
        spriteRenderer.sprite = offSprite;
    }
}
