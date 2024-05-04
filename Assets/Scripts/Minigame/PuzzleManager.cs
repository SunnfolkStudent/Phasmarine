using System.Collections;
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
            counter = 0;
            isChecking = true;
            foreach (var obj in TileListe)
            {
                if (obj.GetComponent<TileCheck>().IsCorrect)
                {
                    counter++;
                    Debug.Log("the counter is " + counter);
                    if (counter >= 20)
                    {
                        Debug.Log("All right");
                        var timelineController = GameObject.Find("FadeOutControler").GetComponent<TimelineStarter>();
                        if (timelineController != null)
                        {
                            timelineController.StartTimeline();
                        }
                        else
                        {
                            print("timlinecontroler is null");
                        }
                    }
                }
                else
                {
                    //counter = 0;
                    //break;
                }
            }
//Counter blir 20 men kjører ikke kan være fordi det er 21 ting som sjekkes?
           

            isChecking = false;
        }
    }

}
