using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This script handles the UI Text of the timer and counts down from the specified time given in Unity.
//It requires a public float timeLeft in order to set the time in Unity.

public class TimerScript : MonoBehaviour
{
    Text text;
    public float timeLeft;
   

    //This method gets the text from the UI engine in the game at the start of the scene
    void Start()
    {
        text = GetComponent<Text>();
    }

    //This method subtracts one second from the timer every frame
    void Update()
    {
        if (Mathf.Round(timeLeft) == 0.0) {
            TimeOver();

        }
        timeLeft -= Time.deltaTime;
        text.text = "Time left: " + Mathf.Round(timeLeft);


    }
    public void TimeOver() {
       
        text.color = Color.red;
        SceneManager.LoadScene("TitleScene");
    }
 
}