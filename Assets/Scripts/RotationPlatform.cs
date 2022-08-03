using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlatform : MonoBehaviour
{

    public float rotateSpeed;

    [SerializeField]  private bool rotationCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationCheck == true)
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        }
        if (rotationCheck == false)
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime * -1f);
        }
    }

    
}
