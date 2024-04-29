using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //Hent listen fra andre script 
    public List<GameObject> TileListe = new List<GameObject> ();
    public int counter = 0;
    private MiniGameManager _miniGameManager;

    //funker men teller samme tile flere ganger hvis du setter fram og tilbake og kan telle mellom 1 til tre i counter per plasserte tile
    void Start()
    {
        _miniGameManager = GetComponent<MiniGameManager>();
    }
    public void Checkifworks()
    {
        foreach (var obj in TileListe)
        {
            if(obj.GetComponent<TileCheck>().IsCorrect)
            {
                counter++;
                Debug.Log("the counter is");
                Debug.Log(counter);
            }
            else
            {
                break;
            }
        }
        if (counter == 25)
        {
            Debug.Log("All right");
            _miniGameManager.PuzzleMiniGameDown();
        }
        
    }
}
