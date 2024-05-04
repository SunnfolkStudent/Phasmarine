using UnityEngine;
using FMOD.Studio;

public class KillPlayer : MonoBehaviour
{
    private EventInstance minigameMusicEventInstance;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            minigameMusicEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
            StatickSceneControler.DeathUp();
        }
    }
}
