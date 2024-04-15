using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float groundDist;
    
    [SerializeField] private Transform InteractPoint;

    [SerializeField] private LayerMask terrainLayer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SpriteRenderer sr;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        InteractPoint.transform.parent.SetParent(gameObject.transform);
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        if (moveDir.x < 0 )
        {
            InteractPoint.localPosition = new Vector3(-1f, -0.5f, 0f);
        }
        else if (moveDir.x > 0)
        {
            InteractPoint.localPosition = new Vector3(1f, -0.5f, 0f);
        }
        else if (moveDir.z < 0)
        {
            InteractPoint.localPosition = new Vector3(0f, -0.5f, -1f);
        }
        else if (moveDir.z > 0)
        {
            InteractPoint.localPosition = new Vector3(0f, -0.5f, 1f);
        }
        


        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if(x != 0 && x > 0)
        {
            sr.flipX = false;
        }
    }
}
