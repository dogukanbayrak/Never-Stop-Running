using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    RaycastHit cube;
    [SerializeField] private float lightRange;
    public LayerMask lm;
    public GameObject brush;
    public float brushSize = 0.1f;
    public float brushSpeed;
    public float brushHorizontalSpeed;


    private Rigidbody rb;
    private bool rotateCheck=false;
    Vector3 pos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up*brushSpeed);
        pos = transform.position;
    }
    void Update()
    {
        if (MainCharacterController.paintCheck)
        {
            Paint();
            Movement();
        }

        
        
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
    void Movement()
    {
        if (rotateCheck)
        {
            rb.AddForce(Vector3.down * brushSpeed);
        }
        else if (!rotateCheck)
        {
            rb.AddForce(Vector3.up * brushSpeed);
        }

        if (Input.GetKey("d"))
        {
            rb.velocity += Vector3.right * brushHorizontalSpeed;
           
        }
        if (Input.GetKey("a"))
        {
            rb.velocity += Vector3.left * brushHorizontalSpeed;

        }


    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BrushRotate")
        {
            rb.velocity = new Vector3(0, 0, 0);
            rotateCheck = !rotateCheck;
        }

        if (other.gameObject.tag == "HorizontalReset")
        {
            transform.position = pos;
        }


    }

}
