using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject character;
    Vector3 offset;
    

    void Start()
    {
        offset = transform.position - character.transform.position;
    }

    
    void LateUpdate()
    {
        if (!MainCharacterController.paintCheck)
        {
            transform.position = character.transform.position + offset;
        }
        if (MainCharacterController.paintCheck)
        {
            gameObject.transform.position = new Vector3(-3, 24, 1573);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }
}
