using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

     /// <summary>
    /// Item Handler script manages interactions between the player and objects that the player collides with.
    /// </summary>
public class ItemHandler : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    GameObject pickedItem;
    [Tooltip("Instance of playerMovementController that gives access to the ApplySpeed method")]
     PlayerMovementController playerMovement;
    [Tooltip("Instance of playerHealthController that gives access to the Hurt method")]
    [SerializeField] PlayerHealthController playerHealth;
    public GameObject pauseMenuPanel;
  

    public AudioClip audioWin; // win
    public AudioClip audioLose; // lose

    void Start()
    {
        playerMovement = GetComponent<PlayerMovementController>();
        playerHealth = GetComponent<PlayerHealthController>();
        pauseMenuPanel.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Peach"))
        {

            if (pickedItem == null)
            {
                AudioSource.PlayClipAtPoint(audioWin, transform.position);
                pickedItem = other.gameObject;
                //if it's a peach reduce scale of player
                transform.localScale += new Vector3(-0.5f, -0.5f, 0);
                Destroy(pickedItem);
            }
        }


        if (other.CompareTag("Pizza"))
        {

            if (pickedItem == null)
            {
                AudioSource.PlayClipAtPoint(audioLose, transform.position);
                pickedItem = other.gameObject;
                //if it's a pizza increase scale of player
                transform.localScale += new Vector3(1, 1, 1);
                Destroy(pickedItem);
            }
        }


        if (other.CompareTag("Star"))
        {
            if (pickedItem == null)
            {
                AudioSource.PlayClipAtPoint(audioWin, transform.position);
                pickedItem = other.gameObject;
                Destroy(pickedItem);
                //if it's a star increase velocity of player
                playerMovement.ApplySpeed(3.0f, 8.0f);
                }
            }


        if (other.CompareTag("Door"))
        {
            //move from tutorial scene to scene 1
           if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName("TutorialScene")) 
         {
         SceneManager.LoadScene ("Scene1");
         }
        //move from scene 1 to scene 2
             else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName("Scene1"))
         {
         SceneManager.LoadScene ("Scene2");
         }
         //move from scene 2 to title scene
             else{
            SceneManager.LoadScene ("TitleScene"); 
         }


           
            
        }

        //Player gets hurt when they fall from the play area and loads the title screen
        if (other.CompareTag("PlayArea"))
        {
            playerHealth.Hurt();

        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName("TutorialScene")) 
         {
         SceneManager.LoadScene ("TitleScene");
         }
        else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName("Scene1")) 
         {
         SceneManager.LoadScene ("TitleScene");
         }
 
        else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName("Scene2"))
         {
         pauseMenuPanel.SetActive(true);
         }
          
        }

    }
    
    //player looses life when they hit spikes
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Spikes"))
        {
            AudioSource.PlayClipAtPoint(audioLose, transform.position);
            playerHealth.Hurt();
        }
    }

    //player looses life when they hit spikes
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.CompareTag("Bird"))
        {
            AudioSource.PlayClipAtPoint(audioLose, transform.position);
            playerHealth.Hurt();
        }
    }

}

