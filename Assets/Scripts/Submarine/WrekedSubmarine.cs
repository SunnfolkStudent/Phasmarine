using UnityEngine;

public class WrekedSubmarine : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _prompt = "Salwage";
    }

    public bool Interact(Interactor interactor)
    {
        print("colectedPart");
        MiniGameManager.Parts += 1;
        Destroy(this);
        return false;
    }
}
