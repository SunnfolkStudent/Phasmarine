using UnityEngine;

public class SubmarineDoorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;
    [SerializeField] private int maxParts = 3;

    public string InteractionPrompt => _prompt;

    private void Update()
    {
        if (MiniGameManager.Parts < maxParts)
        {
            _prompt = "You need " + (maxParts - MiniGameManager.Parts) + " parts to continue";
        }
        else
        {
            _prompt = "You can Continue";
        }
    }

    public bool Interact(Interactor interactor)
    {
        if (MiniGameManager.Parts >= maxParts)
        {
            if (StatickSceneControler.level == 1)
            {
                StatickSceneControler.PuzzleMiniGameUp();
                print("trying to opne puzzel 1");
            }
            if (StatickSceneControler.level == 2)
            {
                StatickSceneControler.PuzzleMiniGameUp2();
                print("trying to opne puzzel 2");
            }
            if (StatickSceneControler.level == 3)
            {
                StatickSceneControler.PuzzleMiniGameUp();
                print("trying to opne puzzel 3");
            }
            return true;
        }
        return false;
    }
}
