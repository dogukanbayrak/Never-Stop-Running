using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{

    [Header("Player Settings")]
    public GameObject player;
    public Animator anim;
    public Rigidbody rb;
    public float speed;
    public float speedLimit;
    public float jumpSpeed;
    public float horizontalSpeed;
    public float horizontalSpeedLimit;
    private bool horizontalBrake;
    public float horizontalInput;

    private bool readyToJump;
    Vector3 pos;
    public static bool paintCheck = false;

    //[Header("Rankings Settings")]
    //public float playerDistance;
    //public GameObject[] points;
    //public PositionManager master;

    [Header("Rankings Settings")]

    public float distance;
    public Transform destinationPoint;





    [Header("Platform Settings")]

    public float platformForce;
    private bool platformLeftCheck;
    private bool platformRightCheck;


    

    void Start()
    {
        anim = GetComponent<Animator>();
        pos = transform.position;
    }

    
    void Update()
    {
        if (platformLeftCheck == true)
        {
            PlatformRotationLeft();
        }
        if (platformRightCheck == true)
        {
            PlatformRotationRight();
        }

        if (!paintCheck)
        {
            Movement();

            Jumping();

            HorizontalBrakeSystem();
        }
        else if (paintCheck)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            anim.SetBool("runCheck", false);
        }

        distance = Vector3.Distance(transform.position, destinationPoint.position);
        //Debug.Log(distance);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            readyToJump = true;            
            anim.SetBool("jumpCheck", false);
            anim.SetBool("runCheck", true);
        }
        if(collision.gameObject.tag == "Enemy")
        {

            transform.position = pos;
        }
        if (collision.gameObject.tag == "RotationLeft")
        {
            platformLeftCheck = true;

        }
        if (collision.gameObject.tag == "RotationRight")
        {
            platformRightCheck = true;
            

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FinishLine")
        {
            paintCheck = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            readyToJump = false;
            
        }
        if (collision.gameObject.tag == "RotationLeft")
        {
            platformLeftCheck = false;

        }
        if (collision.gameObject.tag == "RotationRight")
        {
            platformRightCheck = false;

        }
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readyToJump==true)
        {
            
            anim.SetBool("jumpCheck", true);
            
            rb.velocity += Vector3.up * jumpSpeed;
            readyToJump = false;
        }
    }
    void Movement()
    {
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        
        rb.MovePosition(rb.position + forwardMove);


        

        if (rb.velocity.x < 50f)
        {
            if (Input.GetKey("d"))
            {
                rb.velocity += Vector3.right * horizontalSpeed;
                horizontalBrake = false;
                if (speed > 15)
                {
                    speed -= 7f * Time.deltaTime;
                }

                
            }
            if (Input.GetKey("a"))
            {
                rb.velocity += Vector3.left * horizontalSpeed;
                horizontalBrake = false;
                if (speed > 15)
                {
                    speed -= 7f * Time.deltaTime;
                }

               
            }
            if (Input.GetKeyUp("d") || Input.GetKey("a"))
            {
                horizontalBrake = true;

            }
        }

    }

    void HorizontalBrakeSystem()
    {
        if (horizontalBrake)
        {
            speed += 7f * Time.deltaTime;
        }
        if (speed > 31)
        {
            speed = 30f;
        }
    }

    void PlatformRotationLeft()
    {
        rb.velocity += Vector3.left * platformForce;
    }
    void PlatformRotationRight()
    {
        rb.velocity += Vector3.right * platformForce;
    }

    
}

