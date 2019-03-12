
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Player script. Manages the health and interaction with enemies of the player.
/// </summary>

public class PlayerHealthController : MonoBehaviour
{
    public enum PlayerStatus
    {
        Hurt,
        Active,
        InActive,
        Dead
    }

    [Tooltip("Number of lifes of the player.")]
    [SerializeField] int hitPoints = 3;
    [Tooltip("Duration of the blinking and stunning when hurt by an enemy.")]
    [SerializeField] float hurtTimer = 0.1f;
    [Tooltip("Object to be spawned on death.")]
   

   
    SpriteRenderer sr;
    PlayerStatus status;
    Coroutine hurtRoutine;

    void Awake()
    {
     
        sr = GetComponent<SpriteRenderer>();
        status = PlayerStatus.Active;
    }
    

    /// <summary>
    /// Hurt the Player. The player will lose one hitpoint and is invulnerable for hurtTimer time.
    /// </summary>
    public void Hurt()
    {
        if (status != PlayerStatus.Active)
        {
            return;
        }

        hitPoints--;
        UIManager.SetLifes(hitPoints);
        if (hitPoints <= 0)
        {
            Die();
            return;
        }
        if (hurtRoutine != null)
        {
            StopCoroutine(hurtRoutine);
        }
        hurtRoutine = StartCoroutine(HurtRoutine());
    }

    IEnumerator HurtRoutine()
    {
        status = PlayerStatus.Hurt;
        float timer = 0;
        bool blink = false;

        while (timer < hurtTimer)
        {
            blink = !blink;
            timer += Time.deltaTime;
            if (blink)
            {
               
                    sr.color = Color.white;
                
            }
            else
            {
                
                    sr.color = Color.red;
                
            }
            yield return new WaitForSeconds(0.05f);
        }
      
        
            sr.color = Color.white;
        
        status = PlayerStatus.Active;
    }

    /// <summary>
    /// Destroy the player and load the titke scene
    /// </summary>
   public void Die()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject, 3f);
        
    }
}



