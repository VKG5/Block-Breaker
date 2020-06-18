using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config Params
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparkleVFX;
    // [SerializeField] int maxHits=3;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;
    GameStatus gameStatus;

    // State Variables
    [SerializeField] int timesHits=0; // Only serialized for debug purposes

    private void Start() 
    {   
        gameStatus = FindObjectOfType<GameStatus>();
        breakableBlocks();
    }

    void breakableBlocks() 
    {
        // Or you can just type - [SerializeField] Level level; へ
        // Then dragged and dropped the object in the inspector |
        level = FindObjectOfType<Level>(); 
        
        // Calling the method to count the number of breakable objects
        if(tag == "Breakable")
        {
            level.countBreakableBlocks();
        }

        // Debugging Purposes
        // UnityEngine.Debug.Log(level.breakableBlocks);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(tag == "Breakable")
        {
            timesHits++;
            int maxHits = hitSprites.Length + 1;
            if(timesHits >= maxHits)
            {
                DestroyBlock();
            }

            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite() 
    {
        int spriteIndex = timesHits - 1;

        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

        else
        {
            UnityEngine.Debug.LogError("Block sprite missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
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
