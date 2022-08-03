using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{

    public GameObject brush;
    public float brushSize = 0.1f;
    public GameObject paintCam;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && MainCharacterController.paintCheck)
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit))
            {
                var paint = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                paint.transform.localScale = Vector3.one * brushSize;
            }
        }
    }
}
