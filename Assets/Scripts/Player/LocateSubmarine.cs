using UnityEngine;

public class LocateSubmarine : MonoBehaviour
{
    [SerializeField] private Transform subPos;
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform needle;

    private void Update()
    {
        var direction = subPos.position - playerPos.position;

        direction = new Vector3(direction.x,direction.z , 0).normalized;

        var rotation = Quaternion.LookRotation(direction, Vector3.forward);
        
        rotation *= Quaternion.Euler(90, 0, 0);
        
        needle.rotation = rotation;
    }
}
