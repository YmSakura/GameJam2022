using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    private Animator animator;
    public GameObject dialog4;
    private bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isOpen", isOpen);
    }
    
    private void OnMouseDown()
    {
        dialog4.SetActive(true);
    }
}
