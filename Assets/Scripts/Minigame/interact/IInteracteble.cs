using UnityEngine;

public interface IInteracteble
{
    public string InteractionPrompt { get;  }
    public bool Interact (Interactor interactor);
    
    
}


