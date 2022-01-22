using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> slots = new List<GameObject>();//管理生成的5个slots

    private void Start()
    {
        inventory.itemList.Clear();                 //清空列表内的所有物品
        for (int i = 0; i < 5; i++)                 //重新生成五个槽位
        {
            inventory.itemList.Add(null);
        }
        RefreshSlot();                              //刷新背包显示
    }

    public void RefreshSlot()
    {
        for (int i = 0; i < 5; i++)
        {
            if (inventory.itemList[i] == null)  //如果列表当前元素为空,则失活按钮取消显示
                slots[i].SetActive(false);
            else                                //如果列表当前元素为空,则复制相关信息
            {
                slots[i].SetActive(true);
                Image image = slots[i].GetComponentInChildren<Image>();
                image.sprite = inventory.itemList[i].itemImage;
            }
        }
        
    }
}
