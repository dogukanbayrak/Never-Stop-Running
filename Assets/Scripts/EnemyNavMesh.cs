using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    public GameObject enemy;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }


    private void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            enemy.transform.position = new Vector3(0, 1, 0);
        }
    }

}
