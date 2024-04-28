using UnityEngine;

public class SeaweedTrigger : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        StatickSceneControler.CleaningMiniGameUp();
        Destroy(gameObject);
        return true;
    }
    
}
