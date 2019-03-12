// <copyright file="AsteroidSpawn.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>07/14/2017</date>

using UnityEngine;
using System.Collections;
using Random = System.Random;

/// <summary>
/// Object Spawner.Spawns the pizza, peach and star objects.
/// </summary>

public class ObjectSpawn : MonoBehaviour
{
    //objects to instantiate
    public GameObject[] spawnArray;
    float platformSize;
    Rigidbody2D rb2D;
    SpriteRenderer sr;
    public float spawnRate;
    private float lastSpawnTime = 1;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        platformSize = this.GetComponent<Renderer>().bounds.size.y;
    }
   
    void Update()
    {
        if (lastSpawnTime + spawnRate < Time.time)
        {
            spawnObjects();
            lastSpawnTime = Time.time;
        }
    }

    void spawnObjects()
    {
       //spawn objects randomly
        Random random = new Random();
        int spawnIndex = random.Next(0, spawnArray.Length);
        float platformTop = transform.position.y + platformSize /2;
        //gets the center of the platform
        Vector3 spawnCenter = new Vector3(transform.position.x, platformTop + platformSize / 2, transform.position.z);
        Instantiate(spawnArray[spawnIndex], spawnCenter, Quaternion.identity);
     
        

    }

}