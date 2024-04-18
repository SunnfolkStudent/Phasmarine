using System.Collections;
using Player;
using UnityEngine;

public class LightControler : MonoBehaviour
{
    private Light light;
    
    [SerializeField] private float stunCost;
    public static bool scared;
    private bool canStun;


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
        if (!Input.GetKeyDown(KeyCode.F) && canStun) return;
        scared = true;
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
