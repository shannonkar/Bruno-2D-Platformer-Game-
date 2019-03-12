using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// CameraController script. Manages the movement of the camera based on the player's movement.
/// </summary>
public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 lastPos;
    public float offset;
    private void Update()
    {
        float player1Position = player.transform.position.x; 
        lastPos = transform.position;

        if (player != null) {
            Vector3 newPos = new Vector3(player1Position + offset, lastPos.y, -10);

            transform.position = newPos;
        }
       


    }
}
