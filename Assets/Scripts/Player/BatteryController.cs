using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Player
{
    public class BatteryController : MonoBehaviour
    {
        [SerializeField] private Volume _volume;
        
        [SerializeField] private float batteryDrain = 1;
        
        [SerializeField] private float batteryLevel = 100;

        [SerializeField]private float transitionSpeed = 1;
        private float targetIntensity;
        public static float BatteryLevel
        {
            get => instance.batteryLevel;
            set => instance.batteryLevel = value;
        }
        private static BatteryController instance;
        [SerializeField]private float maxBattery = 100;
        
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
                targetIntensity = 1f;
            }
            else
            {
                targetIntensity = 0.3f;
            }
            
            if (_volume.profile.TryGet(out Vignette vignette))
            {
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, targetIntensity, Time.deltaTime * transitionSpeed);
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
