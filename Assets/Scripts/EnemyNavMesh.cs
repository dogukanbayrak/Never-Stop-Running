using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    public GameObject enemy;
    Vector3 pos;

    public float AIdistance;
    public Transform destinationPoint;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    private void Start()
    {
        pos = transform.position;
    }


    private void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;


        AIdistance = Vector3.Distance(transform.position, destinationPoint.position);
        //Debug.Log("enemy distance: " + AIdistance);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            transform.position = pos;
        }
    }

}
