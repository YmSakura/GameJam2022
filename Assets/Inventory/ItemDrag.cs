using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public Inventory inventory;
    private int currentItemID;//当前物品ID

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
        Transform pointFather = pointGameObject.transform.parent.parent;
        if (pointGameObject.name.Substring(0,5) == "Image")//判断下面物体名字是：Item Image 那么互换位置
        {
            transform.SetParent(pointFather);
            transform.position = pointFather.position;
            //itemList的物品存储位置改变
            var temp = inventory.itemList[currentItemID];
            inventory.itemList[currentItemID] = inventory.itemList[pointGameObject.GetComponentInParent<Slot>().slotID];
            inventory.itemList[pointGameObject.GetComponentInParent<Slot>().slotID] = temp;

            pointGameObject.transform.parent.position = originalParent.position;
            pointGameObject.transform.parent.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;//射线阻挡开启，不然无法再次选中移动的物品
            return;
        }
        else if (pointGameObject.name.Substring(0, 4) == "Slot") //判断下面物体名字是：Slot 则直接挂在检测到到Slot下面
        {
            var originItem = pointGameObject.transform.GetChild(0).gameObject;
            originItem.transform.SetParent(originalParent);
            transform.SetParent(pointGameObject.transform);
            transform.position = pointGameObject.transform.position;
            //itemList的物品存储位置改变
            inventory.itemList[pointGameObject.GetComponentInParent<Slot>().slotID] = inventory.itemList[currentItemID];
            inventory.itemList[currentItemID] = null;
        }

        

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
