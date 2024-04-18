using UnityEngine;
using UnityEngine.AI;

public class FishMovement : MonoBehaviour
{
    //[SerializeField]private Animator animator;
    //[SerializeField] private Transform spriteTransform;
    
    [SerializeField] private float displasmendDist = 5f;
    
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Transform target = null;
    
    [SerializeField] private float circleRadius = 5f;
    [SerializeField] private float circleSpeed = 2f;
    [SerializeField] private Vector3 center;
    private float circleAngle = 0f;

    
    private bool wantToAttack = false;
    
    private Vector3 moveDelta;
    
    private Transform fishPos;
    private float lookatAngle = -90f;
    

    private float runAngle;
    
    private bool istargetNull;

    private float timer;
    private bool increseCircleRadius;
    private bool canBeScared;
    private bool curentlyScared = false;

    [SerializeField] private float scaredDuration = 5;
    private float scaredTimer;
    private bool startScaredTimer = false;
    


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
        if (startScaredTimer)
        {
            scaredTimer += Time.deltaTime;
            if (scaredTimer > scaredDuration)
            {
                startScaredTimer = false;
                curentlyScared = false;
                scaredTimer = 0f;
            }
        }
        
        if (LightControler.scared && canBeScared || curentlyScared)
        {
            curentlyScared = true;
            LightControler.scared = false;
            startScaredTimer = true;
            var normDir = (target.position - transform.position).normalized;
            {
                
            }
            normDir = Quaternion.AngleAxis(runAngle, Vector3.up)* normDir;
                
            MoveToPos(transform.position - new Vector3(normDir.x,0,normDir.z) * displasmendDist);
            
        }
        else if (wantToAttack)
        {
            if (target)
                MoveToTarget();
        }
        else
        {
            IdleMovementSirciel();
            /*timer += Time.deltaTime;
            if (timer >= 5)
            {
                print("somting");
                IdleMovementRandomPos(transform.position + new Vector3(Random.Range(-10,10),0,Random.Range(-10,10)));
            }*/
            
        }
        
    }
    
    private void MoveToTarget()
    {
        _agent.SetDestination(target.position);
        _agent.isStopped = false;
    }

    private void MoveToPos(Vector3 pos)
    {
        _agent.SetDestination(pos);
        _agent.isStopped = false;
    }

    private void IdleMovementRandomPos(Vector3 pos)
    {
        print("findingIdleMovmentRandomPos");
        _agent.speed = 5;
        _agent.SetDestination(pos);
        _agent.isStopped = false;
        timer = 0f;
    }

    private void IdleMovementSirciel()
    { 
        timer += Time.deltaTime;
        
        _agent.speed = 3.5f;
        
        circleAngle += circleSpeed * Time.deltaTime;
        var x = center.x + Mathf.Cos(circleAngle) * circleRadius;
        var z = center.z + Mathf.Sin(circleAngle) * circleRadius;

        var circlePosition = new Vector3(x, transform.position.y, z);
        MoveToPos(circlePosition);
        if (!(timer > 10)) return;
        
        if (increseCircleRadius)
        {
            circleRadius += 5;
            increseCircleRadius = false;
        }
        else
        {
            circleRadius -= 5;
            increseCircleRadius = true;
        }
            
        timer = 0;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        
        print("enterd Triger");
        if (other.CompareTag("Player"))
        {
            wantToAttack = true;
            canBeScared = true;
            /*if (Random.Range(1, 3) == 1)
            {
                runAngle = 45;
            }
            else
            {
                runAngle = -45;
            }*/
        }

        if (other.CompareTag("PlayerHitBox"))
        {
            print("player died");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canBeScared = false;
        if (other.CompareTag("Player")) 
            wantToAttack = false;
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
