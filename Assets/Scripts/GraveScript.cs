using System;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;
using FMODUnity;

//Bruke en timer som basescript for oksygensystemet
public class GraveScript : MonoBehaviour, IInteracteble
{
    public int TotalGraves = 10;
    public int TotalParts = 3;
    public int GravesChecked = 0;
    private MiniGameManager _miniGameManager;
    
    [SerializeField] private EventReference laugh;
    [SerializeField] private EventReference huh;
    [SerializeField] private EventReference scrapPick;
    
    public static bool StartTresure = false;
    private bool hasBeenInteracted = false;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        StatickSceneControler.SpinMiniGameUp();
        //Hente ut poengene fra spinminigame til å påvirke sjansene dine i treasurefunksjonen
        hasBeenInteracted = true;
        return true;
    }

    private void Update()
    {
        if (!StartTresure || !hasBeenInteracted) return;
        Treasure();
    }

    private void Treasure()
    {
        StartTresure = false;
        var chance = Random.Range(GravesChecked * 5, 100);
        if (chance > 80 || (TotalGraves - GravesChecked) <= (TotalParts - MiniGameManager.Parts))
        {
            //Gi beskjed til spilleren om at de fant en del av ubåten
            Debug.Log("Fant ubåtdel");
            global::AudioManager.instance.PlayOneShot(scrapPick, this.transform.position);
            MiniGameManager.Parts += 1;
        }
        else if (chance > 50)
        {
            Debug.Log("Skummel greie");
            global::AudioManager.instance.PlayOneShot(laugh, this.transform.position);
            BatteryController.BatteryLevel -= 50;
            
        }
        else
        {
            Debug.Log("Ingenting skjedde");
            global::AudioManager.instance.PlayOneShot(huh, this.transform.position);
        }
        GravesChecked += 1;
        Destroy(transform.parent.gameObject);
    }
    
}

