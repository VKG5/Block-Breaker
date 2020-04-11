using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Parameters
    // Serialize for debugging purposes
    [SerializeField] int breakableBlocks;
    
    // Cache reference
    SceneLoader sceneLoader;

    public void Start() 
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void countBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void blockDestroyed()
    {
        breakableBlocks--;

        if (breakableBlocks<=0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
