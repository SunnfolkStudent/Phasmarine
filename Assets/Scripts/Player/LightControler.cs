using System.Collections;
using Player;
using UnityEngine;
using FMODUnity;

public class LightControler : MonoBehaviour
{
    private Light light;
    
    [SerializeField] private float stunCost;
    [SerializeField] private EventReference stun;
    
    public static bool scared;
    private bool canStun = true;


    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        Stun();
    }

    private void Stun()
    {
        if (!Input.GetKeyDown(KeyCode.F) || !canStun) return;
        canStun = false;
        scared = true;
        AudioManager.instance.PlayOneShot(stun, this.transform.position);
        BatteryController.BatteryLevel -= stunCost;
        StartCoroutine(IStopStun());
    }

    private IEnumerator IStopStun()
    {
        yield return new WaitForSeconds(1);
        scared = false;
        yield return new WaitForSeconds(10);
        canStun = true;
    }
    
}
