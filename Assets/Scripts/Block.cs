﻿using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockSound;
    
    // Cached reference
    Level level;
    GameStatus gameStatus;

    private void Start() 
    {
        // Or you can just type - [SerializeField] Level level; へ
        // Then dragged and dropped the object in the inspector |
        level = FindObjectOfType<Level>();    
        gameStatus = FindObjectOfType<GameStatus>();

        // Calling the method to count the number of breakable objects
        level.countBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy();
    }

    private void Destroy()
    {
        // Because this is a 3d effect, Camera.main, to access Main Camera
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.blockDestroyed();
        gameStatus.AddToScore();
    }
}
