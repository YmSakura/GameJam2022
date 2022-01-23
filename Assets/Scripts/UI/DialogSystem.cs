using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textContent;
    public TextAsset textFile;
    public float textSpeed;     //打字机速度
    private bool cancelTyping;  //是否取消打字机效果
    private bool textFinished;  //是否完成typing
    List<string> textList = new List<string>(); //用来存放每一行的文本内容
    private int index;          //数组的下标即行数

    void Awake()
    {
        //初始化，切割文本
        GetTextFromFile(textFile);
    }
    
    void Update()
    {
        //更新文本内容
        SetText();
    }
    
    
    //对话框每次打开自动播放第一行内容
    private void OnEnable()
    {
        //不使用协程的做法，直接输出每一行的文本内容
        //textContent.text = textList[index++];
        
        //初始状态默认打字完成，才能进入协程
        textFinished = true;
        index = 0;
        StartCoroutine(SetTextUI());
    }
    
    IEnumerator SetTextUI()
    {
        textFinished = false;
        //每次都先清空Text的内容
        textContent.text = "";
        
        //letter即每一行文本的String数组的下标，为了和index区分用letter表示
        int letter = 0;
        //当玩家按下R键将cancelTyping置为true时结束循环，否则逐字显示每一行的文本内容
        while (!cancelTyping && letter < textList[index].Length - 1)
        {
            //每次添加一个字
            textContent.text += textList[index][letter++];
            //以下语句的作用就是每隔textSpeed秒执行一次循环，并且不会执行循环后面的内容，直到循环结束
            yield return new WaitForSeconds(textSpeed);
        }
        
        //如果循环未结束就退出循环（即按了R），则直接输出此行文本内容
        textContent.text = textList[index];
        
        //本行输出完毕，切换状态，index++更新到下一行
        cancelTyping = false;
        textFinished = true;
        index++;
    }
    
    //更新文本内容
    void SetText()
    {
        //文本结束再按空格则关闭对话框
        if (Input.GetKeyDown(KeyCode.Space) && index >= textList.Count)
        {
            index = 0;
            gameObject.SetActive(false);
            return;
        }
        
        //按空格更新文本内容，只有一行结束才可以更新到下一行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textFinished && !cancelTyping)
            {
                //如果上一行已经finished并且没有cancelTyping就开启协程
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished)
            {
                //如果正在输出文本内容，此时按下空格可以取消打字机效果，直接显示整行内容
                cancelTyping = !cancelTyping;
            }
        }
    }
    
    
    //切割文本，只在Awake执行
    void GetTextFromFile(TextAsset file)
    {
        //清空list以及index
        textList.Clear();

        //按行切割文本文件，用临时的String数组保存，数组中每个元素为一行
        var lineDate = file.text.Split('\n');
        foreach (var line in lineDate)
        {
            //复制文本内容，因为数组没法直接赋值，所以采用for循环的方式
            textList.Add(line);
        }
    }
}
