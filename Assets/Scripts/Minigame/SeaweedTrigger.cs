using UnityEngine;

public class SeaweedTrigger : MonoBehaviour, IInteracteble
{
    private int foundpart= 0;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if (foundpart == 0)
        {
            StatickSceneControler.CleaningMiniGameUp();
            foundpart++;
        }
        else if (foundpart == 1)
        {
            StatickSceneControler.CleaningMiniGameUp2();
            foundpart++;
        }
        
        else if (foundpart == 2)
        {
            StatickSceneControler.CleaningMiniGameUp3();
            foundpart++;
        }
        Debug.Log(foundpart);
        Destroy(gameObject);
        return true;
    }
    
}
