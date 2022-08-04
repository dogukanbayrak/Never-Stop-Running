using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDenemeleri : MonoBehaviour
{
    RaycastHit cube;
    [SerializeField] private float lightRange;
    public LayerMask lm;
    public GameObject brush;
    public float brushSize = 0.1f;



    void Update()
    {
        
            Paint();
        
    }

    

    public void Paint()
    {
        if (Physics.Raycast(transform.position, transform.forward, out cube, lightRange, lm))
        {
            //Debug.Log(cube.transform.tag);
            if(cube.transform.tag!="BrushArea"){
                var rotate = Quaternion.Euler(-90, 0f, 0f);
                var paint = Instantiate(brush, cube.point + Vector3.back * 0.1f, rotate);
                paint.transform.localScale = Vector3.one * brushSize;
                
            }
            
        }
    }

}
