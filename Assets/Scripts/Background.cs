using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Background script. Loops the background as the player moves through the level.
/// </summary>
public class Background : MonoBehaviour
{
    [Tooltip("Background that is looped")]
    [SerializeField] public GameObject background;
    private float backgroundWidth = 18;
    private Vector3 CurrBackground;
    private bool flip;
    public float offset;


    // Start is called before the first frame update
    void Start()
    {
      flip = true;
      CurrBackground = new Vector3(transform.position.x, transform.position.y, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > (CurrBackground.x - (backgroundWidth / 2)))
        {
            Vector3 newPosition = new Vector3(CurrBackground.x + backgroundWidth + offset, CurrBackground.y, 0);
            CurrBackground = newPosition;

            if (flip)
            {
                //flips  every other background spawned on the y axis
                Instantiate(background, newPosition, Quaternion.Euler(new Vector3(0, 180, 0)));
                flip = false;
            }
            else
            {
                Instantiate(background, newPosition, Quaternion.identity);
                flip = true;
            }
        }
    }
}
