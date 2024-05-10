using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using FMODUnity;

public class WrekedSubmarine : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;
    [SerializeField] private EventReference scrapPick;

    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _prompt = "Salvage";
    }

    public bool Interact(Interactor interactor)
    {
        AudioManager.instance.PlayOneShot(scrapPick, this.transform.position);
        MiniGameManager.Parts++;
        Destroy(gameObject);
        return true;
    }

}
