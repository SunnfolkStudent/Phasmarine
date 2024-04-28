using Player;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBarUI : MonoBehaviour
{
    [SerializeField] private Image oxygenBar;

    [SerializeField] private float maxBattery;

    [SerializeField] private float lerpSpeed;
    private void Update()
    {
        oxygenBar.fillAmount = Mathf.Lerp(oxygenBar.fillAmount,BatteryController.BatteryLevel / maxBattery,lerpSpeed);
    }
}
