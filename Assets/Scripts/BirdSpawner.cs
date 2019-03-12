using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bird spawner script. Spawns the bird objects
/// </summary>
public class BirdSpawner : MonoBehaviour
{
    public float speed;
    public float lifeSpan;
    Vector2 direction = new Vector2();
    
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0, -1);
        // normalize direction so it does not impact the travel speed
        direction.Normalize();
       

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
            lifeSpan = Time.deltaTime;
        }
    }
  
}

