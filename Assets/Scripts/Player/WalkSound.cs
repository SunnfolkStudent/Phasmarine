using FMOD.Studio;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    private EventInstance footstepsSand; // The FMOD event path for footsteps sound
    public void Walk()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.footstepsSand, this.transform.position);
    }
}
