using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    private Animator animator;
    public GameObject dialog4,dialog7;
    public Inventory inventory;
    public Item key, Diary;
    public static bool isOpen, hasKey;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isOpen", isOpen);
        if (inventory.itemList.Contains(key))
            hasKey = true;
    }
    
    private void OnMouseDown()
    {
        if (hasKey)
        {
            dialog7.SetActive(true);
            if (!inventory.itemList.Contains(Diary))//如果不存在当前物品,如果存在则跳过
            {
                for (int i = 0; i < 5; i++)
                {
                    if(inventory.itemList[i]!=null) continue;
                    inventory.itemList[i]=Diary;       //则在背包列表中添加当前物品
                    break;
                }
                InventoryManager.iInstance.RefreshSlot();
            }
        }
        else
        {
            dialog4.SetActive(true);
        }
    }
    
}
