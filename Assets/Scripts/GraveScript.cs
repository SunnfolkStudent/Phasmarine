using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

//Bruke en timer som basescript for oksygensystemet
public class GraveScript : MonoBehaviour, IInteracteble
{
    public int TotalGraves = 10;
    public int TotalParts = 3;
    public int GravesChecked = 0;
    public int parts = 0;
    public float MonsterFaster= 1;
    private MiniGameManager _miniGameManager;

    private void Start()
    {
        _miniGameManager = GetComponent<MiniGameManager>();
    }

    public bool Interact(Interactor interactor)
        {
                _miniGameManager.SpinMiniGameUp();
            //Hente ut poengene fra spinminigame til å påvirke sjansene dine i treasurefunksjonen
            GravesChecked += 1;
            Treasure();
            Destroy(gameObject);
            return true;
        }


    private void Treasure()
        {
            int chance;
            chance = Random.Range(GravesChecked * 5, 100);
            if (chance > 80 || (TotalGraves-GravesChecked) <= (TotalParts-parts))
            {
                //Gi beskjed til spilleren om at de fant en del av ubåten
                Debug.Log("Fant ubåtdel");
                MonsterFaster += 1;
                parts += 1;
                
            }
            
            else if (chance>50)
            {
                Debug.Log("Skummel greie");
                MonsterFaster += 3;
            }
            
            else if (chance >30)
            {
                //Legge inn andre objects
            }
            
            else
            {
                Debug.Log("Ingenting skjedde");
            }
}

    public string InteractionPrompt { get; }

}

