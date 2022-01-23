using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject manAtPast;
    public Room room;
    public Door door;
    public Calendar calendar;
    public GameObject endPanel;

    void ClosePast()
    {
        room.UpdateSprite();
        door.isOpen = false;
        manAtPast.SetActive(false);
        calendar.gameObject.SetActive(false);
        Invoke("OpenPanel", 1f);
    }

    void OpenPanel()
    {
        endPanel.SetActive(true);
    }
}
