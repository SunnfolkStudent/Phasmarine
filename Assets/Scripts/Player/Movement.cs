using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float groundDist;
    
        [SerializeField] private Transform InteractPoint;
        [SerializeField] private Transform lightTransform;

        [SerializeField] private LayerMask terrainLayer;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform sr;
        [Header("Animator")]
        [SerializeField]private Animator anim;

        private Vector3 lastMoveDir;

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

            if (Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.z))
            {
                if (moveDir.x < 0)
                {
                    InteractPoint.localPosition = new Vector3(-1f, -0.5f, 0f);
                    lightTransform.localPosition = new Vector3(-0.3f, 0, -0.2f);
                }
                else if (moveDir.x > 0)
                {
                    InteractPoint.localPosition = new Vector3(1f, -0.5f, 0f);
                    lightTransform.localPosition = new Vector3(0.3f, 0, -0.2f);
                }
            }
            else
            {
                if (moveDir.z < 0)
                {
                    InteractPoint.localPosition = new Vector3(0f, -0.5f, -1f);
                    lightTransform.localPosition = new Vector3(0.2f, 0, -0.25f);
                }
                else if (moveDir.z > 0)
                {
                    InteractPoint.localPosition = new Vector3(0f, -0.5f, 1f);
                    lightTransform.localPosition = new Vector3(-0.25f, 0, 0.2f);
                }
            }
            
            if (moveDir != Vector3.zero)
            {
                lastMoveDir = moveDir.normalized;
            }
            
            if (rb.velocity.magnitude < 0.1f)
            {
                anim.SetFloat("MoveX", lastMoveDir.x);
                anim.SetFloat("MoveY", lastMoveDir.z);
            }
            else
            {
                anim.SetFloat("MoveX", x);
                anim.SetFloat("MoveY", y);
            }
            anim.SetBool("moving", new Vector2(x,y) != Vector2.zero );
        }
            /*if (x != 0 && x < 0)
            {
                sr.localScale = new Vector3(1, 1, 1);
            }
            else if(x != 0 && x > 0)
            {
                sr.localScale = new Vector3(1, 1, -1);
            }*/
    }
}
