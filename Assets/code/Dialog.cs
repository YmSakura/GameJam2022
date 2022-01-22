using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject dialog1;
    private void Update() {
        if(Input.GetKeyDown("space")){
        dialog1.SetActive(false);
    }
    }
    
}
