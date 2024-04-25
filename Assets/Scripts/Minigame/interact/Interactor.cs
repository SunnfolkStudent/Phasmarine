using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public UnityEvent InteractableFound = new UnityEvent();
    
    [SerializeField] private Transform _interactPoint;
    [SerializeField] private float _interactRadius;
    [SerializeField] private LayerMask interactableMask;

    [SerializeField] private InteractionPrompUI promptUI;

    [SerializeField] private int _numbFound;
    private readonly Collider[] _colliders = new Collider[3];

    private IInteracteble interactable;


    private void Start()
    {
        
    }

    private void Update()
    {
        _numbFound = Physics.OverlapSphereNonAlloc(_interactPoint.position, _interactRadius, _colliders, interactableMask);

        if (_numbFound > 0)
        {
            
             interactable = _colliders[0].GetComponent<IInteracteble>();
             promptUI = _colliders[0].GetComponent<InteractionPrompUI>();

             if (interactable != null)
             {
                 InteractableFound?.Invoke();
                 if (!promptUI.isDisplayed)
                 {
                     promptUI.SetUp(interactable.InteractionPrompt);
                 }
                 if (interactable != null && Input.GetKeyDown(KeyCode.E))
                 {
                     interactable.Interact(this);
                 }
                 
             }
             
        }
        else
        {
            if (interactable != null) interactable = null;
            if (promptUI.isDisplayed) promptUI.Close();
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactPoint.position,_interactRadius);
    }
}
