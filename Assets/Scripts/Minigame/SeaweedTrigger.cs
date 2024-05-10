using UnityEngine;

public class SeaweedTrigger : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    
    private bool hasBeenInteracted = false;
    public bool Interact(Interactor interactor)
    {
        StatickSceneControler.CleaningMiniGameUp();
        Destroy(gameObject);
        return true;
    }
    
}
