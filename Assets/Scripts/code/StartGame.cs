using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class StartGame : MonoBehaviour
{
   public void startGame(){
       EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().buildIndex+1);
   }
}
