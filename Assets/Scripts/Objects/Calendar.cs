using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;              //用于获取material
    private Animator animator;
    public Material defaultMaterial, flashMaterial;     //普通的材质，用于替换
    public GameObject dialog2, dialog3;
    private bool isBig;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isBig", isBig);
    }

    //计时结束后发光
    public void Open()
    {
        StartCoroutine(Timer());
    }

    //协程计时器
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        Flash();
    }
    
    //切换为发光材质
    public void Flash()
    {
        spriteRenderer.material = flashMaterial;
        //触发对话框
        dialog2.SetActive(true);
    }
    
    //点击之后切换默认材质
    private void OnMouseDown()
    {
        spriteRenderer.material = defaultMaterial;
        dialog2.SetActive(false);
        isBig = true;
    }

    public void OpenDialog()
    {
        dialog3.SetActive(true);
    }

    public void CloseDialog()
    {
        if (!dialog3.activeSelf)
        {
            isBig = false;
        }
    }
}
