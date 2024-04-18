using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Player
{
    public class BatteryController : MonoBehaviour
    {
        [SerializeField] private Volume _volume;
        
        [SerializeField] private float batteryDrain = 1;
        [SerializeField] private float maxBattery;
        [SerializeField] private float batteryLevel = 100;
        
        public static float BatteryLevel
        {
            get => instance.batteryLevel;
            set => instance.batteryLevel = value;
        }
        private static BatteryController instance;

        private void Awake()
        {
            instance = this;
        }
        private void Update()
        {
            BatteryLevel = Mathf.Clamp(BatteryLevel, 0f ,maxBattery);
            BatteryLevel -= batteryDrain * Time.deltaTime;

            
            if (BatteryLevel < 20)
            {
                if (_volume.profile.TryGet(out Vignette vignette))
                {
                    vignette.intensity.value = 1f;
                }
            }
            else
            {
                if (_volume.profile.TryGet(out Vignette vignette))
                {
                    vignette.intensity.value = 0.3f;
                }
            }

            if (!(BatteryLevel <= 0))
            {
                _volume.profile.TryGet(out ColorAdjustments colorAdjustmentss);
                colorAdjustmentss.postExposure.value = 0f;
            }
            else
            {
                _volume.profile.TryGet(out ColorAdjustments colorAdjustments);
                colorAdjustments.postExposure.value -= 0.1f;

                if (colorAdjustments.postExposure.value <= -10)
                {
                   print("PlayerDied"); 
                }
                
            }
            
        }
        
    }
    
}
