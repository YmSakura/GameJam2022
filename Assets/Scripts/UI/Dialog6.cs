using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog6 : MonoBehaviour
{
    public Inventory inventory;
    public Item keys;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(gameObject.GetComponentInChildren<TextMeshProUGUI>().text.Substring(0,4));
            if (gameObject.GetComponentInChildren<TextMeshProUGUI>().text.Substring(0, 4) == "相框背后")
            {
                if (!inventory.itemList.Contains(keys))//如果不存在当前物品,如果存在则跳过
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if(inventory.itemList[i]!=null) continue;
                        inventory.itemList[i]=keys;       //则在背包列表中添加当前物品
                        
                        break;
                    }
                    //加个背包的提示
                    InventoryManager.iInstance.RefreshSlot();
                }
            }
            gameObject.SetActive(false);
        }
    }
}
