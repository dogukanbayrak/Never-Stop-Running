using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class PositionManager : MonoBehaviour
{
    public float[] playerPositions;
    
    public float playerPosition;

    public int playerCurrentPosition;

    public TextMeshProUGUI posText;


    [Header("ex")]
    public static List<float> distanceList;
    

    
    

    public void Awake()
    {
        distanceList = new List<float>();
        
    }
    private void Start()
    {
        playerPositions = new float[distanceList.Count];
    }

    void Update()
    {
        
        PositionCalculator();
        PositionTextUpdate();
        
    }



    //public void PositionCalc()
    //{
        
    //    playerPositions[0] = player.GetComponent<MainCharacterController>().distance;
    //    playerPositions[1] = AI[0].GetComponent<EnemyNavMesh>().AIdistance;
    //    //playerPositions[2] = AI[1].GetComponent<EnemyNavMesh>().AIdistance;

    //    playerPosition = player.GetComponent<MainCharacterController>().distance;

    //    Array.Sort(playerPositions);

    //    int x = Array.IndexOf(playerPositions,playerPosition);

    //    Debug.Log(x+"sssssssssssssssssssssssssssssssssssss");

    //}


    public void PositionCalculator()
    {
        playerPosition = distanceList[MainCharacterController.indexFinder];

        for (int i =0; i< distanceList.Count; i++)
        {
            playerPositions[i] = distanceList[i];
        }
        Array.Sort(playerPositions);

        playerCurrentPosition = Array.IndexOf(playerPositions, playerPosition);

        


    }
    public void PositionTextUpdate()
    {
        int posTextFixer = playerCurrentPosition +1 ;
        posText.text = posTextFixer.ToString()+ " / " + distanceList.Count;
    }

}
