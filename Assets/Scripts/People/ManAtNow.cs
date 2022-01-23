using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAtNow : MonoBehaviour
{
    public Inventory inventory;
    public Item Flower, Diary;
    private Animator animator;
    public GameObject woman, hug;
    public static bool hasDiary, hasFlower, atNow;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        /*if (inventory.itemList.Contains(Flower))
            hasFlower = true;*/
        animator.SetBool("hasFlower",hasFlower);
        if (Woman.isWatchingMan && hasFlower)
        {
            gameObject.SetActive(false);
            woman.SetActive(false);
            hug.SetActive(true);
        }
    }

    private void ThrowDiary()
    {
        //丢掉日记的动画
        
        //日记进入背包
        
    }
}
