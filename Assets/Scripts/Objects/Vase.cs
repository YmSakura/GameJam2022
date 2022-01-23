using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public Inventory inventory;
    public Item flower;
    private Animator animator;
    private bool hasFlower;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (inventory.itemList.Contains(flower))
            hasFlower = true;
        animator.SetBool("hasFlower", hasFlower);
    }
}
