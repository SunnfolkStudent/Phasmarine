using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UboatTrigger : MonoBehaviour
{
    private MiniGameManager _miniGameManager;

    private void Start()
    {
        _miniGameManager = GetComponent<MiniGameManager>();
    }
    public bool Interact(Interactor interactor)
    {
        _miniGameManager.PuzzleMiniGameUp();
        //Gå til neste level??
        //Destroy(gameObject);
        return true;
    }
    
    public string InteractionPrompt { get; }

}
