using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

//Bruke en timer som basescript for oksygensystemet
public class GraveScript : MonoBehaviour
{
    public Collider Grave;
    public int GravesChecked = 0;
    public int parts = 0;
    public float MonsterFaster= 1;
   
    private void OnTriggerEnter(Collider other)
    {
        //if Keyboard.Ekey.pressed
        {
            GravesChecked += 1;
            Treasure();
            Destroy(other);
        }
        
    }

    private void Treasure()
        {
            int chance;
            chance = Random.Range(GravesChecked * 5, 100);
            if (chance > 80)
            {
                Debug.Log("Skummel greie");
                MonsterFaster += 3;
            }
            
            else if (chance>50 && parts<3)
            {
                //Gi beskjed til spilleren om at de fant en del av ubåten
                Debug.Log("Fant ubåtdel");
                MonsterFaster += 1;
                parts += 1;
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
        
    }

