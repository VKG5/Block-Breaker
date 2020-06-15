using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Cached reference
    GameStatus gameStatus;

    public void LoadNextScene()
    {
        gameStatus = FindObjectOfType<GameStatus>();

        int n = SceneManager.sceneCountInBuildSettings;
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(((currSceneIndex + 1) % n)==0)
        {
            gameStatus.Reset();
        }

        SceneManager.LoadScene((currSceneIndex + 1) % n);    
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
