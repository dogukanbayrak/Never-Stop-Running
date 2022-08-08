using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PositionManager : MonoBehaviour
{
    public float[] playerPositions;
    public GameObject player;
    public float playerPosition;
    public GameObject[] AI;
    
    //public TextMeshProUGUI posText;

    
    void Update()
    {
        PositionCalc();


    }



    public void PositionCalc()
    {
        
        playerPositions[0] = player.GetComponent<MainCharacterController>().distance;
        playerPositions[1] = AI[0].GetComponent<EnemyNavMesh>().AIdistance;
        //playerPositions[2] = AI[1].GetComponent<EnemyNavMesh>().AIdistance;

        playerPosition = player.GetComponent<MainCharacterController>().distance;

        Array.Sort(playerPositions);

        int x = Array.IndexOf(playerPositions,playerPosition);

        Debug.Log(x+"sssssssssssssssssssssssssssssssssssss");

    }

}
