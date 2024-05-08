using FMOD.Studio;
using UnityEngine;


public class KillPlayer : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.minigameMusicEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
            StatickSceneControler.DeathUp();
        }
    }
}
