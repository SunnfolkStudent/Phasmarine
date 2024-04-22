using System.Collections;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField][Range(0,360)] private float angle;

    [SerializeField] private GameObject playerRef;

    [SerializeField] private LayerMask targetMask;
    
    public bool canSeePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator FOVRoutine()
    {
        float delay =  0.2f;
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeCheks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeCheks.Length != 0)
        {
            Transform target = rangeCheks[0].transform;
            Vector3 directionToTarget = target.position - transform.position.normalized;

            if (Vector3.Angle(transform.position, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }

    }
}
