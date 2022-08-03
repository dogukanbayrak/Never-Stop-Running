using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;


    private void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //if (!MainCharacterController.paintCheck)
        //{
        //    cam1.SetActive(true);
        //    cam2.SetActive(false);
        //}
        //else if(MainCharacterController.paintCheck)
        //{
        //    cam1.SetActive(false);
        //    cam2.SetActive(true);
        //}

        //if (MainCharacterController.paintCheck)
        //{
        //    cam1.transform.position = new Vector3(190, 20, 285);
           
        //}
        


        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    cam1.SetActive(true);
        //    cam2.SetActive(false);
        //}
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    cam1.SetActive(false);
        //    cam2.SetActive(true);
        //}
    }

    

}
