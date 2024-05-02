using UnityEngine;
using FMODUnity;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StatickSceneControler.DeathUp();
        }
    }
}
