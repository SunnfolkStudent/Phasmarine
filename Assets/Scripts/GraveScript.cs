using System;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

//Bruke en timer som basescript for oksygensystemet
public class GraveScript : MonoBehaviour, IInteracteble
{
    public int TotalGraves = 10;
    public int TotalParts = 3;
    public int GravesChecked = 0;
    private MiniGameManager _miniGameManager;

    [SerializeField] private GameObject parent;

    public static bool StartTresure = false;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        StatickSceneControler.SpinMiniGameUp();
        //Hente ut poengene fra spinminigame til å påvirke sjansene dine i treasurefunksjonen
        GravesChecked += 1;
        Destroy(parent);
        return true;
    }

    private void Update()
    {
        if (!StartTresure == true)return;
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
            MiniGameManager.Parts += 1;
        }
        else if (chance > 50)
        {
            Debug.Log("Skummel greie");
            BatteryController.BatteryLevel -= 50;
        }
        else
        {
            Debug.Log("Ingenting skjedde");
        }
    }


}

