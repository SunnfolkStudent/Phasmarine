using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance { get; private set; }
    
    public int seaweedleft = 7;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void CleaningMiniGameUp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CleaningMiniGame", LoadSceneMode.Additive);
        
    }

    public void CleaningMiniGameDown()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("CleaningMiniGame");
    }
    
    public void PuzzleMiniGameUp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PuzzleMiniGame", LoadSceneMode.Additive);
        
    }

    public void PuzzleMiniGameDown()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("PuzzleMiniGame");
    }
    
    public void SpinMiniGameUp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SpinMiniGame", LoadSceneMode.Additive);
        
    }

    public void SpinMiniGameDown()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("SpinMiniGame");
    }
}
