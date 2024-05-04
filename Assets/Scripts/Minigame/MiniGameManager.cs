using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    public void PuzzleMiniGameUp()
    {
        SceneManager.LoadScene("PuzzleMiniGame", LoadSceneMode.Additive);
    }

    public void SpinMiniGameDown()
    {
        SceneManager.UnloadSceneAsync("SpinMiniGame");
    }
}
