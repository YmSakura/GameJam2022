using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InteractableObjects : MonoBehaviour,IPointerDownHandler
{
    public Inventory inventory;         //获取背包
    public Item thisItem;               //当前物品
    public InventoryManager inventoryManager;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (AddItem())
        {
            inventoryManager.RefreshSlot();
            Destroy(gameObject);//添加成功，删除当前物品
        }

        else
        {
            //添加错误
        }
    }


    public bool AddItem()//添加到背包中
    {
        if (!inventory.itemList.Contains(thisItem))//如果不存在当前物品,如果存在则跳过
        {
            for (int i = 0; i < 5; i++)
            {
                if(inventory.itemList[i]!=null) continue;
                inventory.itemList[i]=thisItem;       //则在背包列表中添加当前物品
                return true;
            }
            //加个背包的提示
        }
        else
        {
            //当前物品已存在(应该不会出现这种bug
        }
        return false;
    }
    
}
