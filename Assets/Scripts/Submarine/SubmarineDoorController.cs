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
            _prompt = "You need" + (maxParts - MiniGameManager.Parts) + "To continue";
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
            print("go to next level");
            return true;
        }
        return false;
    }
}
