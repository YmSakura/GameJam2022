using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    private Animator animator;
    public GameObject dialog4,dialog7;
    public static bool isOpen, hasKey;

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
        if (hasKey)
        {
            dialog7.SetActive(true);
        }
        else
        {
            dialog4.SetActive(true);
        }
    }
}
