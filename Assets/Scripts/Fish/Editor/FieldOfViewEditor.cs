using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        
        if (Application.isPlaying)
        {
            Vector3 agentDirection = fov.fishMovement._agent.desiredVelocity.normalized;
            Vector3 leftBoundary = Quaternion.Euler(0, -fov.angle / 2, 0) * agentDirection;
            Vector3 rightBoundary = Quaternion.Euler(0, fov.angle / 2, 0) * agentDirection;
                    
            Handles.color = Color.yellow;
            Handles.DrawLine(fov.transform.position, fov.transform.position + leftBoundary * fov.radius);
            Handles.DrawLine(fov.transform.position, fov.transform.position + rightBoundary * fov.radius);  
                    
        }
        else
        {
            Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2); 
            Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);
        }
        
        if (fov.canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.playerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
