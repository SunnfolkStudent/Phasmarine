using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //Hent listen fra andre script 
    public List<GameObject> TileListe = new List<GameObject> ();
    private int counter = 0;
    private MiniGameManager _miniGameManager;

    //funker men teller samme tile flere ganger hvis du setter fram og tilbake og kan telle mellom 1 til tre i counter per plasserte tile
    void Start()
    {
        _miniGameManager = GetComponent<MiniGameManager>();
    }

    private bool isChecking = false;
    public void Checkifworks()
    {
        if (isChecking == false)
        {
            isChecking = true;
            foreach (var obj in TileListe)
            {
                if (obj.GetComponent<TileCheck>().IsCorrect)
                {
                    counter++;
                    Debug.Log("the counter is");
                    Debug.Log(counter);
                }
                else
                {
                    counter = 0;
                    break;
                }
            }

            if (counter >= 21)
            {
                Debug.Log("All right");
                StatickSceneControler.nextLevel();
            }

            isChecking = false;
        }
    }
}
