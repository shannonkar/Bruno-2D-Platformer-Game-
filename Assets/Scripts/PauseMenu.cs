using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script controls the Pause menu, allowing the user to press escape on their keyboard and pop up the pause menu.
//It requires a public GameObject from UI to have an interactive button menu.

public class PauseMenu : MonoBehaviour
{
    bool open;
    
    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        Close();
    }

    // Update is called once per frame
    void Update()
    {
        //check for pressing escape
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (open)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    //This method makes the pause menu show up
    public void Open()
    {
        open = true;
        Time.timeScale = 0;
        menuPanel.SetActive(true);
    }
    
    //This method is called to resume the game from the pause menu
    public void Close()
    {
        open = false;
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }

    //This method references the build settings to load a scene
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
