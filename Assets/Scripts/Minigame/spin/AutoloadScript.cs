using UnityEngine;

public class AutoloadScript : MonoBehaviour
{
    public float speed = 4;
    private float range = 30;
    public float score = 0;

    public bool innenfor = false;

    public float pilpos = 360;
    public float spotpos = 360;
    private Vector2 spotrange = new Vector2(0, 0);

    private void Update()
    {
        spotrange = new Vector2(spotpos - range, spotpos + range);
        if ((pilpos >= spotrange.x && pilpos <= spotrange.y) || (pilpos -360 >= spotrange.x && pilpos -360 <= spotrange.y))
        {
            innenfor = true;
        }
        else
        {
            innenfor = false;
        }
        
    }

    

}
