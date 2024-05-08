using UnityEngine;
using FMODUnity;

public class WrekedSubmarine : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;
    [SerializeField] private EventReference scrapPick;

    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _prompt = "Salwage";
    }

    public bool Interact(Interactor interactor)
    {
        AudioManager.instance.PlayOneShot(scrapPick, this.transform.position);
        print("colectedPart");
        MiniGameManager.Parts += 1;
        Destroy(gameObject);
        return false;
    }
}
