using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script enables the game to load a scene from scene manager based on the integer
//value passed to it, which references the build settings.

public class LoadScreenOnClick : MonoBehaviour
{
    //This method takes in an int and uses the scene manager to load
    //the scene that corresponds to the int's index in the build settings
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
