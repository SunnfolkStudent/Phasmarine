using UnityEngine;

public class WrekedSubmarine : MonoBehaviour
{
    [SerializeField] private string _prompt;
    [SerializeField] private int maxParts = 1;

    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _prompt = "Salwage";
    }

    public bool Interact(Interactor interactor)
    {
        MiniGameManager.Parts += 1;
        return true;
    }
}
