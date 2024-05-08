using UnityEngine;

public class SeaweedTrigger : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    
    public static bool destroySewed = false;
    private bool hasBeenInteracted = false;
    public bool Interact(Interactor interactor)
    {
        hasBeenInteracted = true;
        
        StatickSceneControler.CleaningMiniGameUp();
        return true;
    }

    private void Update()
    {
        if (!destroySewed || !hasBeenInteracted) return;
        hasBeenInteracted = false;
        Destroy(gameObject);
    }
}
