using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class DeathControler : MonoBehaviour
{
    private EventInstance playerDiedEventInstance;
    
    private void Start()
    {
        InitializeplayerDied(FMODEvents.instance.playerDied);
    }

    private void InitializeplayerDied(EventReference playerDiedEventReference)
    {
        playerDiedEventInstance = RuntimeManager.CreateInstance(playerDiedEventReference);
        playerDiedEventInstance.start();
    }

    public void Revive()
    {
        
        if (StatickSceneControler.level == 1)
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (StatickSceneControler.level == 2)
        {
            SceneManager.LoadScene("LevelOne");
        }
        if (StatickSceneControler.level == 3)
        {
            SceneManager.LoadScene("Leveltwo");
        }
    }
}
