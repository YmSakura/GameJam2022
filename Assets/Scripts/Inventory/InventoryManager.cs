using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager iInstance;
    public Inventory inventory;
    public List<GameObject> slots = new List<GameObject>();//管理生成的5个slots

    private void Start()
    {
        iInstance = this;
        inventory.itemList.Clear();                 //清空列表内的所有物品
        for (int i = 0; i < 5; i++)                 //重新生成五个槽位
        {
            inventory.itemList.Add(null);
        }
        RefreshSlot();                              //刷新背包显示
    }

    public void RefreshSlot()
    {
        GameObject tmp;
        for (int i = 0; i < 5; i++)
        {
            tmp = slots[i].transform.GetChild(0).gameObject;
            if (inventory.itemList[i] == null) //如果列表当前元素为空,则失活按钮取消显示
            { 
                tmp.SetActive(false);
                slots[i].GetComponent<Slot>().slotItem = null;
            }
            else                                //如果列表当前元素为空,则复制相关信息
            {
                tmp.SetActive(true);
                slots[i].GetComponent<Slot>().slotItem = inventory.itemList[i];
                Image image = slots[i].transform.GetChild(0).GetComponentInChildren<Image>();
                image.sprite = inventory.itemList[i].itemImage;
            }
        }
        
    }
}
