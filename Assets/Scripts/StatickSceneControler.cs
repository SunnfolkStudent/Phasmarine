using UnityEngine.SceneManagement;

public static class StatickSceneControler
{
    public static void CleaningMiniGameUp()
    {
        SceneManager.LoadScene("CleaningMiniGame", LoadSceneMode.Additive);
        
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
    }
}
