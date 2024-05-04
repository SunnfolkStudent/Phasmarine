using UnityEngine.SceneManagement;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance { get; private set; }
    
    public static int Parts= 0;
    
    [HideInInspector]public int seaweedleft = 13;

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
        SceneManager.LoadScene("CleaningMiniGame", LoadSceneMode.Additive);
        
    }

    public void CleaningMiniGameDown()
    {
        SceneManager.UnloadSceneAsync("CleaningMiniGame");
    }
    
    public void CleaningMiniGameDown2()
    {
        SceneManager.UnloadSceneAsync("Cleaning2");
    }
    public void CleaningMiniGameDown3()
    {
        SceneManager.UnloadSceneAsync("Cleaning3");
    }

    
    public void PuzzleMiniGameUp()
    {
        SceneManager.LoadScene("PuzzleMiniGame", LoadSceneMode.Additive);
        
    }

    public void PuzzleMiniGameDown()
    {
        SceneManager.UnloadSceneAsync("PuzzleMiniGame");
    }
    
    public void SpinMiniGameUp()
    {
        SceneManager.LoadScene("SpinMiniGame", LoadSceneMode.Additive);
        
    }

    public void SpinMiniGameDown()
    {
        SceneManager.UnloadSceneAsync("SpinMiniGame");
    }
}
