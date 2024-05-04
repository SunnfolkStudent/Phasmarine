using UnityEngine;

public class SubmarineDoorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;
    [SerializeField] private int maxParts = 3;
    private int doorCounter = 0;

    public string InteractionPrompt => _prompt;

    private void Update()
    {
        if (MiniGameManager.Parts < maxParts)
        {
            _prompt = "You need " + (maxParts - MiniGameManager.Parts) + " parts to continue";
        }
        else
        {
            _prompt = "You can Continue";
        }
    }

    public bool Interact(Interactor interactor)
    {
        if (MiniGameManager.Parts == maxParts)
        {
            if (doorCounter== 0)
            {StatickSceneControler.PuzzleMiniGameUp();}
            if (doorCounter== 1)
            {StatickSceneControler.PuzzleMiniGameUp();}
            doorCounter++;
            return true;
        }
        return false;
    }
}
