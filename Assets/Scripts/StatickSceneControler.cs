using Player;
using UnityEngine.SceneManagement;

public static class StatickSceneControler
{
    public static int level = 1;
    public static void CleaningMiniGameUp()
    {
        SceneManager.LoadScene("CleaningMiniGame", LoadSceneMode.Additive);
        Movement.canMove = false;
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
        Movement.canMove = true;
    }
    public static void CleaningMiniGameDown2()
    {
        SceneManager.UnloadSceneAsync("Cleaning2");
    }
    public static void CleaningMiniGameDown3()
    {
        SceneManager.UnloadSceneAsync("Cleaning3");
    }
    
    public static void PuzzleMiniGameUp()
    {
        SceneManager.LoadScene("PuzzleMiniGame", LoadSceneMode.Additive);
        Movement.canMove = false;
    }
    
    public static void PuzzleMiniGameUp2()
    {
        SceneManager.LoadScene("Puzzle2", LoadSceneMode.Additive);
        Movement.canMove = false;
    }
    
    public static void PuzzleMiniGameUp3()
    {
        SceneManager.LoadScene("Puzzle3", LoadSceneMode.Additive);
        Movement.canMove = false;
    }


    public static void PuzzleMiniGameDown()
    {
        SceneManager.UnloadSceneAsync("Puzzle3");
        Movement.canMove = true;
    }
    
    public static void SpinMiniGameUp()
    {
        SceneManager.LoadScene("SpinMiniGame", LoadSceneMode.Additive);
        Movement.canMove = false;
    }

    public static void SpinMiniGameDown()
    {
        SceneManager.UnloadSceneAsync("SpinMiniGame");
        Movement.canMove = true;
    }

    public static void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
        Movement.canMove = true;
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

    public static void EndingUp()
    {
        SceneManager.LoadScene("Ending");
    }
    public static void PuzzleMiniGameDown3()
    {
        SceneManager.UnloadSceneAsync("Puzzle3");
    }
    

    public static void nextLevel()
    {
        MiniGameManager.Parts = 0;
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("LevelOne");
                Movement.canMove = true;
                Interactor.canInteract = true;
                level = 2;  
                break;
            case 2:
                SceneManager.LoadScene("Leveltwo");
                Interactor.canInteract = true;
                Movement.canMove = true;
                level = 3;
                break;
        }
    }

    public static void TryAgain()
    {
        MiniGameManager.Parts = 0;
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
