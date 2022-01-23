using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item FixedPhoto;
    //public InventoryManager inventoryManager;
    public GameObject InfoPanel;                    //物品说明提示界面
    public Transform originalParent;
    public Inventory inventory;
    private int currentItemID;//当前物品ID

    private void Awake()
    {
        originalParent=transform.parent;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var item = inventory.itemList[gameObject.transform.parent.GetComponent<Slot>().slotID];
        InfoPanel.SetActive(true);
        InfoPanel.GetComponentInChildren<TextMeshProUGUI>().text = 
            "物品名称:" + item.itemName + "\n" + "物品介绍:" + item.itemInfo;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InfoPanel.SetActive(false);
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;                          //设置原始父级,记录原始槽位
        currentItemID = originalParent.GetComponent<Slot>().slotID; //记录当前位置ID
        transform.SetParent(originalParent.parent);                 //设置成槽位父级防止图片被槽位图像遮挡
        transform.position = eventData.position;            //物品跟随鼠标移动
        GetComponent<CanvasGroup>().blocksRaycasts = false;         //射线阻挡关闭
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;                //图片跟随鼠标移动
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);     //输出鼠标当前位置下到第一个碰到到物体名字
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject pointGameObject = eventData.pointerCurrentRaycast.gameObject;

        if (!pointGameObject||pointGameObject.gameObject==originalParent.gameObject)
            resetPosition();
        else if (pointGameObject.name == "Item Image")//判断下面物体名字是：Item Image 那么互换位置
        {
            Transform pointFather = pointGameObject.transform.parent.parent;
            int targetID = pointFather.GetComponent<Slot>().slotID;
            if (inventory.itemList[targetID].itemName == "结婚照" && inventory.itemList[currentItemID].itemName == "相框"
                || inventory.itemList[targetID].itemName == "相框" && inventory.itemList[currentItemID].itemName == "结婚照")
            {
                resetPosition();
                inventory.itemList[currentItemID] = null;
                originalParent.GetChild(0).gameObject.SetActive(false);
                inventory.itemList[targetID] = FixedPhoto;
                InventoryManager.iInstance.RefreshSlot();
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            resetPosition();
            Sprite originalImage = GetComponentInChildren<Image>().sprite;
            GetComponentInChildren<Image>().sprite = pointGameObject.GetComponent<Image>().sprite;
            pointGameObject.GetComponent<Image>().sprite = originalImage;
            //itemList的物品存储位置改变
            targetID = pointGameObject.GetComponentInParent<Slot>().slotID;
            //交换背包列表中的内容
            (inventory.itemList[currentItemID], inventory.itemList[targetID]) = (inventory.itemList[targetID], inventory.itemList[currentItemID]);
            InventoryManager.iInstance.RefreshSlot();
            GetComponent<CanvasGroup>().blocksRaycasts = true;//射线阻挡开启，不然无法再次选中移动的物品
            return;
        }
        else if (pointGameObject.name.Substring(0, 4) == "Slot") //判断下面物体名字是：Slot 则直接挂在检测到到Slot下面
        {
            resetPosition();
            
            Sprite image = GetComponentInChildren<Image>().sprite;
            originalParent.GetChild(0).gameObject.SetActive(false);
            pointGameObject.transform.GetChild(0).gameObject.SetActive(true);
            pointGameObject.transform.GetChild(0).GetComponentInChildren<Image>().sprite = image;
            //itemList的物品存储位置改变
            inventory.itemList[pointGameObject.GetComponentInParent<Slot>().slotID] = inventory.itemList[currentItemID];
            inventory.itemList[currentItemID] = null;
            InventoryManager.iInstance.RefreshSlot();
        }
        else
            resetPosition();
        

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void resetPosition()//如果移动失败,物品归位移动到本来的框
    {
        transform.SetParent(originalParent);
        transform.position = originalParent.position;
    }
}
