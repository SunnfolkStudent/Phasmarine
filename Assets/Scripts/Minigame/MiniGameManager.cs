using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
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
