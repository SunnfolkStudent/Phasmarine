using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactPoint;
    [SerializeField] private float _interactRadius;
    [SerializeField] private LayerMask _interactbleMask;

    [SerializeField] private int _numbFound;
    private readonly Collider[] _colliders = new Collider[3];

    private void Update()
    {
        _numbFound = Physics.OverlapSphereNonAlloc(_interactPoint.position, _interactRadius, _colliders, _interactbleMask);

        if (_numbFound > 0)
        {
            var interactble = _colliders[0].GetComponent<IInteracteble>();

            if (interactble != null && Input.GetKeyDown(KeyCode.E))
            {
                interactble.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactPoint.position,_interactRadius);
    }
}
