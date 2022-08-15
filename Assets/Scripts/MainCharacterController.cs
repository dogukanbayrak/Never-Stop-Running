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
    private bool horizontalBrake;
    public float horizontalInput;

    public  bool rightMovement=false;
    public  bool leftMovement=false;


    private bool readyToJump;
    Vector3 pos;
    public static bool paintCheck;


    [Header("Rankings Settings")]

    public float distance;
    public Transform destinationPoint;
    public static int indexFinder;





    [Header("Platform Settings")]

    public float platformForce;
    private bool platformLeftCheck = false;
    private bool platformRightCheck = false;


    

    void Start()
    {
        paintCheck = false;
        anim = GetComponent<Animator>();
        pos = transform.position;
        PositionManager.distanceList.Add(distance);
        indexFinder = PositionManager.distanceList.Count -1 ;

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
            // for the mobile movement
            MobileMovement();
            //for the pc movement and jumping
            //Movement();
            //Jumping();
            //HorizontalBrakeSystem();
        }
        else if (paintCheck)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            anim.SetBool("runCheck", false);
        }
        


            distance = Vector3.Distance(transform.position, destinationPoint.position);
        PositionManager.distanceList[indexFinder] = distance;
        
        

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
        if (other.gameObject.tag == "Enemy")
        {

            transform.position = pos;
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
        if (Input.GetKeyDown(KeyCode.Space) && readyToJump == true)
        {

            anim.SetBool("jumpCheck", true);

            rb.velocity += Vector3.up * jumpSpeed;
            readyToJump = false;
        }

    }
    void MobileMovement()
    {

        transform.Translate(0, 0, speed * Time.deltaTime);


        Vector3 rightMove = new Vector3(50f, transform.position.y, transform.position.z);
        Vector3 leftMove = new Vector3(-50f, transform.position.y, transform.position.z);




        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if (finger.deltaPosition.x > 50f)
            {
                rightMovement = true;
                leftMovement = false;
            }
            if (finger.deltaPosition.x < -50f)
            {
                rightMovement = false;
                leftMovement = true;
            }

            if (rightMovement)
            {
                transform.position = Vector3.Lerp(transform.position, rightMove, horizontalSpeed * Time.deltaTime);

            }
            if (leftMovement)
            {
                transform.position = Vector3.Lerp(transform.position, leftMove, horizontalSpeed * Time.deltaTime);
            }

            if (Input.touchCount > 0 && readyToJump == true)
            {
                if (finger.deltaPosition.y > 50f)
                {
                    anim.SetBool("jumpCheck", true);
                    rb.velocity = Vector3.zero;
                    rb.velocity = Vector3.up * jumpSpeed;

                    readyToJump = false;
                }
            }
            }
            if (Input.touchCount <= 0)
            {
                rightMovement = false;
                leftMovement = false;
            }
        
    }
        

    void Movement()
    {
        //for the pc version

       Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);

        if (rb.velocity.x < 50f)
        {
            if (Input.GetKey("d"))
            {
               
                rb.velocity += Vector3.right * horizontalSpeed * Time.deltaTime;
                horizontalBrake = false;
                if (speed > 15)
                {
                    speed -= 7f * Time.deltaTime;
                }


            }
            if (Input.GetKey("a"))
            {

                rb.velocity += Vector3.left * horizontalSpeed * Time.deltaTime;
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

