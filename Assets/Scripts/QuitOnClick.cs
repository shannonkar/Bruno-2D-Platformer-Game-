using System.Collections;
using UnityEngine;

//This script allows the user to click on "quit" and the game quits.

public class QuitOnClick : MonoBehaviour
{
    //This method sets isPlaying from Unity Editor to false if 
    //Unity is running and quits the game
    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
