using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman : MonoBehaviour
{
    public static bool isFrameFull, hasDiary;
    public Television television;
    public Door door;
    public Animator anim;

    public void EnterRoom()
    {
        Debug.Log("女主进门");
        //进入房间的动画
        door.isOpen = true;

        //判断是否看到完整的结婚照
        if (isFrameFull)
        {
            //望向相框的动画

            if (hasDiary)
            {
                //阅读日记并看向男方的动画

            }
        }
        else
        {
            //如果没有看到延时30s离开房间
            StartCoroutine(Timer());
        }
    }

    //协程计时器
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(30f);
        ExitRoom();
    }

    void ExitRoom()
    {
        //离开房间的动画

        //电视机状态切换
        television.SwitchStatus();
    }
    private GameObject rb;
    private void Awake() {
    rb=GetComponent<GameObject>();
    }
    private void FixedUpdate() {
        Move();
    }
    void Move(){
        float horizontalmove=Input.GetAxisRaw("Horizontal");
        bool on=Input.GetKey(KeyCode.W);
        bool move=Input.GetKey(KeyCode.S);
        anim.SetFloat("right",Mathf.Abs(horizontalmove));
        anim.SetBool("on",on);
        anim.SetBool("move",move);
    }
}