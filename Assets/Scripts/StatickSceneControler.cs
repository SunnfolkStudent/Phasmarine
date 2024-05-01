using UnityEngine.SceneManagement;

public static class StatickSceneControler
{
    public static int level;
    public static void CleaningMiniGameUp()
    {
        SceneManager.LoadScene("CleaningMiniGame", LoadSceneMode.Additive);
    }
    
    public static void CleaningMiniGameUp2()
    {
        SceneManager.LoadScene("Cleaning2", LoadSceneMode.Additive);
    }
    
    public static void CleaningMiniGameUp3()
    {
        SceneManager.LoadScene("Cleaning3", LoadSceneMode.Additive);
    }

    
    public static void CleaningMiniGameDown()
    {
        SceneManager.UnloadSceneAsync("CleaningMiniGame");
    }
    
    public static void PuzzleMiniGameUp()
    {
        SceneManager.LoadScene("PuzzleMiniGame", LoadSceneMode.Additive);
        
    }

    public static void PuzzleMiniGameDown()
    {
        SceneManager.UnloadSceneAsync("PuzzleMiniGame");
    }
    
    public static void SpinMiniGameUp()
    {
        SceneManager.LoadScene("SpinMiniGame", LoadSceneMode.Additive);
    }

    public static void SpinMiniGameDown()
    {
        SceneManager.UnloadSceneAsync("SpinMiniGame");
    }

    public static void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
        level = 1;
    }

    public static void DeathUp()
    {
        SceneManager.LoadScene("Death");
    }

    public static void nextLevel()
    {
        if (level == 1)
        {
            SceneManager.LoadScene("LevelOne");
            level = 2;
            
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Leveltwo");
            level = 3;
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("MainMenu");
            level = 0;
        }
    }
}
