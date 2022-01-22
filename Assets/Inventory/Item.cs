using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;                     //物品名称
    public Sprite itemImage;                    //物品图片
    [TextArea] public string itemInfo;          //物品说明
    public bool isInteractable;                 //物品是否可以交互
}
