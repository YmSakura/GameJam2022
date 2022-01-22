using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Sprite openSprite, closeSprite;
    private bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool("isOpen", isOpen);
    }

    void OpenCabinet()
    {
        spriteRenderer.sprite = openSprite;
    }
}
