using UnityEngine;
using UnityEngine.AI;

public class FishMovment : MonoBehaviour
{
    //[SerializeField]private Animator animator;
    //[SerializeField] private Transform spriteTransform;
    
    [SerializeField] private float displasmendDist = 5f;
    
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Transform target = null;
    

    public bool folow = false;
    private bool wantToRunAway = false;
    
    private Vector3 moveDelta;
    
    private Transform fishPos;
    private float lookatAngle = -90f;
    

    private float runAngle;
    
    private bool _istargetNull;

    private float timer;
    
    
    

    private void Start()
    {
        timer = 0;
        _agent.speed = 5;
        _agent.updateRotation = false;
        target = GameObject.Find("Player").GetComponent<Transform>();
        
        fishPos = GetComponent<Transform>();
        if (_agent == null)
            if (!TryGetComponent(out _agent))
                Debug.LogWarning(name + "needs navmesh agent");
    }

    private void Update()
    {
        //updateAnimation();
        if (folow)
        {
            if (target)
                MoveToTarget();
        }
        else if (!folow && wantToRunAway)
        {
            Vector3 normDir = (target.position - transform.position).normalized;
            {
                
            }
            normDir = Quaternion.AngleAxis(runAngle, Vector3.up)* normDir;
                
            MoveToPos(transform.position - new Vector3(normDir.x,0,normDir.z) * displasmendDist);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                print("somting");
                IdleMovement(transform.position + new Vector3(Random.Range(-10,10),0,Random.Range(-10,10)));
            }
            
        }
        
    }
    
    private void MoveToTarget()
    {
        _agent.SetDestination(target.position);
        _agent.isStopped = false;
    }

    private void MoveToPos(Vector3 pos)
    {
        _agent.speed = 10;
        _agent.SetDestination(pos);
        _agent.isStopped = false;
    }

    private void IdleMovement(Vector3 pos)
    {
        print("findingIdleMovment");
        _agent.speed = 5;
        _agent.SetDestination(pos);
        _agent.isStopped = false;
        timer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("enterd Triger");
        if (other.CompareTag("Player"))
        {
            wantToRunAway = true;
            if (Random.Range(1, 3) == 1)
            {
                runAngle = 45;
            }
            else
            {
                runAngle = -45;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
            wantToRunAway = false;
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fishPos != null && target != null)
            {
                /*Vector3 direction = target.position - jackalopPos.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - lookatAngle, Vector3.up);
                jackalopPos.rotation = rotation*/;
            }
            else
            {
                print("somting is null");
            }
        }
        
    }

    /*private void updateAnimation()
    {
        animator.SetBool("Moving", _agent.velocity != Vector3.zero);

        Vector3 desiredVelocity = _agent.desiredVelocity;
    
        desiredVelocity.y = 0f;
        
        if (desiredVelocity != Vector3.zero)
        {
            desiredVelocity.Normalize();
        }
        Vector3 localDesiredVelocity = transform.InverseTransformDirection(desiredVelocity);

        if (localDesiredVelocity.x > 0)
        {
            spriteTransform.localScale = new Vector3(1f,1f,1f);
        }
        else if (localDesiredVelocity.x < 0)
        {
            spriteTransform.localScale = new Vector3(-1f,1f,1f);
        }

        animator.SetFloat("MoveX", localDesiredVelocity.x);
        animator.SetFloat("MoveY", localDesiredVelocity.z);
    }*/
}
