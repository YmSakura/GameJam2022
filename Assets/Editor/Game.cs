using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEditor.SceneManagement;

public class Game : MonoBehaviour
{
    private VideoPlayer Vp;
    private void Awake()
    {
        Vp = GetComponent<VideoPlayer>();
    }
    private void Start()
    {
    }
    void Update()
    {
        if (!Vp.isPlaying)
        {

            EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().buildIndex+1);

        }


    }
}
