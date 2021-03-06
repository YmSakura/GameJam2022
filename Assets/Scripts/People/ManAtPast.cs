using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAtPast : MonoBehaviour
{
    public Inventory inventory;
    public Item Flower;
    private Animator animator;
    public static bool hasFlower;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("hasFlower",hasFlower);
    }
}
