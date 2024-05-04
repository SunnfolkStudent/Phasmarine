using System.Collections;
using Player;
using UnityEngine;
using FMODUnity;
using UnityEngine.VFX;

public class LightControler : MonoBehaviour
{
    private Light light;
    [SerializeField] private VisualEffect vfx;
    
    [SerializeField] private float stunCost;
    [SerializeField] private EventReference stun;
    [SerializeField] private EventReference nostun;
    
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
        vfx.Play();
        BatteryController.BatteryLevel -= stunCost;
        StartCoroutine(IStopStun());

        if (!Input.GetKeyDown(KeyCode.F) && (canStun = false)) AudioManager.instance.PlayOneShot(nostun, this.transform.position);
    }

    private IEnumerator IStopStun()
    {
        yield return new WaitForSeconds(1);
        scared = false;
        yield return new WaitForSeconds(10);
        canStun = true;
    }
    
}
