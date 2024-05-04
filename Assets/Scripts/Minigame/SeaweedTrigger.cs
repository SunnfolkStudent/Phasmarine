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
        /*if (MiniGameManager.Parts == 0)
        {
            StatickSceneControler.CleaningMiniGameUp();
        }
        else if (MiniGameManager.Parts == 1)
        {
            StatickSceneControler.CleaningMiniGameUp2();
        }
        else if (MiniGameManager.Parts == 2)
        {
            StatickSceneControler.CleaningMiniGameUp3();
            
        }*/
        
    }
    
}
