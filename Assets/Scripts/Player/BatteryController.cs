using UnityEngine;

namespace Player
{
    public class BatteryController : MonoBehaviour
    {
        public static float BatteryLevel;

        [SerializeField] private float batteryDrain = 1;
        [SerializeField] private float maxBattery = 100;

        private void Update()
        {
            BatteryLevel = Mathf.Clamp(BatteryLevel, 0f ,maxBattery);
            BatteryLevel -= batteryDrain * Time.deltaTime;

            if (BatteryLevel == 0)
            {
                print("PlayerDied");
            }
        
        }
    
    }
}
