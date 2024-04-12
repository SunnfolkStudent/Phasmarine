using UnityEngine;

public class Spot : MonoBehaviour
{
    [SerializeField] private AutoloadScript Globus;
    [SerializeField] private RectTransform transform;
    
    private bool kantrykke = true;

    private void Update()
    {
         if (Input.GetKeyDown("space") && kantrykke == true)
         {
             if (Globus.innenfor == false)
             {
                 Globus.score -= 1;
                 if (Globus.innenfor == true)
                 {
                     Globus.score += 1;
                     Globus.spotpos += UnityEngine.Random.Range(60, 300);
                     if (Globus.spotpos >= 720)
                     {
                         Globus.spotpos -= 360;
                         transform.Rotate(new Vector3(0,0,Globus.spotpos));
                     }
                     
                 }
                                               
             }
         }
        
            
        
           
    }
   
}
