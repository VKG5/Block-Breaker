using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparkleVFX;

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
        playBlockBreakSFX();

        Destroy(gameObject);

        TriggerSparklesVFX();

        level.blockDestroyed();
        gameStatus.AddToScore();
    }

    private void playBlockBreakSFX()
    {
        // Because this is a 3d effect, Camera.main, to access Main Camera
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
