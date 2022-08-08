using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentsAI : MonoBehaviour
{
    
    void Start()
    {
        NavMeshAgent nMesh = GetComponent<NavMeshAgent>();
        nMesh.destination = new Vector3(0, 0, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
