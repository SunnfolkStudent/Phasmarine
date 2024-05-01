using UnityEngine;

public class SeaweedTrigger : MonoBehaviour, IInteracteble
{
    private int foundpart= 0;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        //if (foundpart== 0)
        //{StatickSceneControler.CleaningMiniGameUp()}
        //if else(foundpart==1)
        //{StatickSceneControler.CleaningMiniGameUp()}
        Destroy(gameObject);
        return true;
    }
    
}
