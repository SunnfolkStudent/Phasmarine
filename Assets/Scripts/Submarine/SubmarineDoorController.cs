using UnityEngine;

public class SubmarineDoorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;
    [SerializeField] private int maxParts = 3;
    

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
            MiniGameManager.instance.PuzzleMiniGameUp();
            //Gå til neste level??
            //Destroy(gameObject);
            return true;
        }
        return false;
    }
}
