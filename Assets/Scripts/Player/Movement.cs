using UnityEngine;
using FMOD.Studio;

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

        public static bool canMove;
        
        //audio
        private EventInstance footstepsSand;
        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
            InteractPoint.transform.parent.SetParent(gameObject.transform);

            footstepsSand = AudioManager.instance.CreateInstance(FMODEvents.instance.footstepsSand);

        }
        
        

        private void UpdateSound()
        {
            // start footstep event if the player has an x velocity and is on the ground
            if (rb.velocity.x != 0)
            {
                PLAYBACK_STATE playbackState;
                footstepsSand.getPlaybackState(out playbackState);
                if (playbackState.Equals(PLAYBACK_STATE.STOPPED ))
                {
                    footstepsSand.start();
                }
                
            }

            //otherwise stop footsteps event
            else
            {
                footstepsSand.stop(STOP_MODE.ALLOWFADEOUT);
            }
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

            if (!canMove) return;
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 moveDir = new Vector3(x, 0, y);
            Vector3 newVelocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
            rb.velocity = newVelocity;
            
            
            UpdateSound();

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
            
            UpdateSound();
            
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
            
            UpdateSound();
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
