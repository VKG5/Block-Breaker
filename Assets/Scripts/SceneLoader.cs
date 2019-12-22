using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int n = SceneManager.sceneCountInBuildSettings;
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currSceneIndex + 1) % n);    
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
