using UnityEngine;

public class Pil : MonoBehaviour
{
    [SerializeField] private AutoloadScript Globus;
    [SerializeField] private RectTransform transform;

    private void Update()
    {
        if (Globus.pilpos >= 720 - Globus.speed)
        {
            Globus.pilpos -= 360;
        }
        
        Globus.pilpos += Globus.speed;
        transform.Rotate(new Vector3(0,0,Globus.pilpos - 360));  
    }

    

}
