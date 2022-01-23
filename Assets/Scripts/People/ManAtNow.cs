using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAtNow : MonoBehaviour
{
    public Inventory inventory;
    public Item Flower, Diary;
    private Animator animator;
    public GameObject woman, hug;
    public static bool hasDiary, hasFlower, atNow;
    public GameObject dialog5;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        hasFlower = ManAtPast.hasFlower;
        animator.SetBool("hasFlower",hasFlower);
        animator.SetBool("hasDiary", hasDiary);
        if (Woman.isWatchingMan && hasFlower)
        {
            gameObject.SetActive(false);
            woman.SetActive(false);
            hug.SetActive(true);
        }
    }

    private void ThrowDiary()
    {
        hasDiary = false;
    }

    public void OpenDialog()
    {
        dialog5.SetActive(true);
    }
    
    
}
