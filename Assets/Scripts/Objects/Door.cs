using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite openSprite, closeSprite;
    private Animator animator;
    public bool isOpen;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        animator.SetBool("isOpen",isOpen);
    }

    void OpenDoor()
    {
        spriteRenderer.sprite = openSprite;
    }

    void CloseDoor()
    {
        spriteRenderer.sprite = closeSprite;
    }
}
