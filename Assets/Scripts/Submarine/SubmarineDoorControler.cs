using System;
using UnityEngine;

public class SubmarineDoorControler : MonoBehaviour, IInteracteble
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _prompt = "sdfasef";
    }

    public bool Interact(Interactor interactor)
    {
        return false;
    }
}
