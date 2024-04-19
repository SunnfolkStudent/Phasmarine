using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public void DialogueSceneGameBeginningUp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DialogueBeginningScene", LoadSceneMode.Additive);
        
    }

    public void DialogueSceneBeginningDown()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("DialogueBeginningScene");
    }
    
    public void DialogueSceneGameUp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DialogueScene", LoadSceneMode.Additive);
        
    }

    public void DialogueSceneDown()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("DialogueScene");
    }

}
