using UnityEngine;

public class SeaweedTrigger : MonoBehaviour, IInteracteble
{
    private MiniGameManager _miniGameManager;

    private void Start()
    {
        _miniGameManager = GetComponent<MiniGameManager>();
    }
    public bool Interact(Interactor interactor)
    {
        _miniGameManager.CleaningMiniGameUp();
        Destroy(gameObject);
        return true;
    }
    
    public string InteractionPrompt { get; }
    
}
