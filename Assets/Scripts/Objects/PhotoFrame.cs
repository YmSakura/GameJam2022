using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhotoFrame : MonoBehaviour,IPointerDownHandler
{
    public GameObject tipPanel;
    /*private void OnMouseDown()
    {
        Woman.isFrameFull = true;
    }*/
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        tipPanel.GetComponentInChildren<TextMeshProUGUI>().text = "相框背后好像有东西,要看一看吗,(按下空格以继续).";
        tipPanel.SetActive(true);
    }
}
