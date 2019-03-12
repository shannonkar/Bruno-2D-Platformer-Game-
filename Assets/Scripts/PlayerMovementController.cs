using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
  public float speed = 5f;
  public Sprite upSprite;
  public Sprite normal;
  public Sprite leftSprite;
  public float jumpSpeed = 8f;
  private float movement = 0f;
  private Rigidbody2D rigidBody;
  private SpriteRenderer sr;
  public Transform groundCheckPoint;
  public float groundCheckRadius;
  public LayerMask groundLayer;
  public LayerMask platformLayer;
  private bool isTouchingGround;
  private bool isTouchingPlatform;


  /*private bool isTouchingStar;
  public float armCheckRadius;
  public LayerMask starLayer;*/

  private float waitTime = 3.0f;
  private float timer = 0.0f;
    // Start is called before the first frame update


  float speedPowerUpTimer = -2000;
  float baseSpeed;

    void Start()
    {
      baseSpeed = speed;
      rigidBody = GetComponent<Rigidbody2D> ();
      sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
    
      // this is where we update the speed/powerups
      UpdatePowerUp();

      timer += Time.deltaTime;
      // this deals with the jump having a layer
      isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
      isTouchingPlatform = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, platformLayer);

        movement = Input.GetAxis("Horizontal");
      // right movement
      if (movement > 0f && Input.GetKey(KeyCode.RightArrow)) {
        sr.flipX = true;
        sr.sprite = leftSprite;
        rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
      }
      else if(movement < 0f && Input.GetKey(KeyCode.LeftArrow)) {
        sr.flipX = false;
        sr.sprite = leftSprite;
        rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
      }
      else {
        sr.sprite = normal;
        rigidBody.velocity = new Vector2 (0,rigidBody.velocity.y);
      }
      if(Input.GetKeyDown(KeyCode.UpArrow) && isTouchingGround){
        sr.sprite = upSprite;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
      }else if (Input.GetKeyDown(KeyCode.UpArrow) && isTouchingPlatform){
        // after a couple of seconds = 3, increase the speed
        jumpSpeed = 10f;
        sr.sprite = upSprite;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
        // if timer is three seconds
        if (timer > waitTime)
          {
              timer = timer - waitTime;
              jumpSpeed = 5f;
          }
          // just to make sure it reverts back after if loop
          jumpSpeed = 5f;
      }
    }

    private void UpdatePowerUp() {
        speedPowerUpTimer -= Time.deltaTime;
        if(speedPowerUpTimer < 0)
        {
            speed = baseSpeed;
        }
    }

    public void ApplySpeed(float time, float speed) {
        speedPowerUpTimer = time;
        this.speed = speed;
    }
}
