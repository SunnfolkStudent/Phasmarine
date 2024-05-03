using Player;
using UnityEngine;
using FMODUnity;
public class Refiloxigen : MonoBehaviour
{
    [SerializeField] private EventReference OxygenRefill;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BatteryController.BatteryLevel += 5;
        }
    }
}
