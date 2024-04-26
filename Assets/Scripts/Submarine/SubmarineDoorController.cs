using UnityEngine;

public class SubmarineDoorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;
    [SerializeField] private int maxParts = 3;

    public string InteractionPrompt => _prompt;

    private void Update()
    {
        if (MiniGameManager.instance.Parts > 0)
        {
            _prompt = "You need" + (MiniGameManager.instance.Parts - maxParts) + "To continue";
        }
        else
        {
            _prompt = "You can Continue";
        }
    }

    public bool Interact(Interactor interactor)
    {
        return false;
    }
}
