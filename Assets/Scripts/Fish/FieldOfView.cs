using System.Collections;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public FishMovement fishMovement;
    
    public float radius;
    [Range(0,360)] public float angle;
    
    public GameObject playerRef;
    
    public LayerMask targetMask;
    
    public bool canSeePlayer;
    
    private void Start()
    {
        fishMovement = GetComponent<FishMovement>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
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
        
        print("inRange");
        if (rangeCheks.Length != 0)
        {
            print(rangeCheks[0]);
            Transform target = rangeCheks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            
            
            if (Vector3.Angle(new Vector3(fishMovement._agent.velocity.x, 0, fishMovement._agent.velocity.z), directionToTarget) < angle / 2)
            {
                
                /*var distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }*/
                canSeePlayer = true;
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
