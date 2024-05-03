using UnityEngine.SceneManagement;

public static class StatickSceneControler
{
    public static int level = 1;
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

    public static void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void DeathUp()
    {
        SceneManager.LoadScene("Death");
    }

    public static void nextLevel()
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("LevelOne");
                level = 2;
                break;
            case 2:
                SceneManager.LoadScene("Leveltwo");
                level = 3;
                break;
            case 3:
                SceneManager.LoadScene("MainMenu");
                level = 0;
                break;
        }
    }

    public static void TryAgain()
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Tutorial");
                break;
            case 2:
                SceneManager.LoadScene("LevelOne");
                break;
            case 3:
                SceneManager.LoadScene("Leveltwo");
                break;
        }
    }
}
