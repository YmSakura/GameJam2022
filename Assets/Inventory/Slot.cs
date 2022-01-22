using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotID;              //空格ID 等于 物品ID
    public Item slotItem;           //槽位的物品


    public GameObject itemInSlot;

    public void SetupSlot(Item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }



    }
}
