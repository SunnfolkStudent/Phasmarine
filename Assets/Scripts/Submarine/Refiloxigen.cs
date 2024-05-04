
using Player;
using UnityEngine;

public class Refiloxigen : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BatteryController.BatteryLevel += 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.oxygenRefill, transform.position);
    }
}
