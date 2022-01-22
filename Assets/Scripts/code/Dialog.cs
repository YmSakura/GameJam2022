using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    private bool dialog2T = false;
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            dialog1.SetActive(false);
        }
        if (Input.GetKeyDown("space") && dialog2T == true)
        {
            dialog2.SetActive(false);
        }
    }
}
