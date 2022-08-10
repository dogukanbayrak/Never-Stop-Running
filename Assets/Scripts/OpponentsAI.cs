using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentsAI : MonoBehaviour
{
    [Header("Opponents Settings")]
    public Animator anim;



    [Header("Nav Settings")]
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    
    Vector3 pos;

    public float AIdistance;
    public int indexFinder;
    public Transform destinationPoint;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    private void Start()
    {
        anim = GetComponent<Animator>();

        pos = transform.position;
        PositionManager.distanceList.Add(AIdistance);
        indexFinder = PositionManager.distanceList.Count -1 ;

        anim.SetBool("destinationCheck", false);
    }


    private void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;


        AIdistance = Vector3.Distance(transform.position, destinationPoint.position);
        PositionManager.distanceList[indexFinder] = AIdistance;
        //Debug.Log("enemy distance: " + AIdistance);

        if (AIdistance < 3)
        {
            anim.SetBool("destinationCheck", true);
            //gameObject.GetComponent<NavMeshAgent>().enabled=false;
            
            
        }
        if (AIdistance > 3)
        {
            anim.SetBool("destinationCheck", false);
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            transform.position = pos;
        }
    }

}
