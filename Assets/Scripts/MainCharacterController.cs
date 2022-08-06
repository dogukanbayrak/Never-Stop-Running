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

    public static bool paintCheck = false;


    [Header("Platform Settings")]

    public float platformForce;
    private bool platformLeftCheck;
    private bool platformRightCheck;


    

    void Start()
    {
        anim = GetComponent<Animator>();
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
        

        //Vector3 direction = Vector3.forward * speed * Time.deltaTime;
        //direction.Normalize();
        //rb.velocity += direction;
        //Debug.Log(rb.velocity);

        //if (rb.velocity.z >= 5f && readyToJump)
        //{
        //    rb.velocity = Vector3.forward * 5f;
        //}
        //else if(!readyToJump)
        //{

        //    rb.velocity = Vector3.forward * 5f;
        //}



        // horizontalInput = Input.GetAxis("Horizontal");



        //if (rb.velocity.z < speedLimit)
        //{
        //    //rb.velocity += Vector3.forward * speed;
        //    rb.AddForce(Vector3.forward * speed);
        //}
        //if (rb.velocity.x < horizontalSpeedLimit)
        //{

        //}


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

            player.transform.position = new Vector3(0, 1, 0);
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
            //transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
            rb.velocity += Vector3.up * jumpSpeed;
            readyToJump = false;
        }
    }
    void Movement()
    {
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        //Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);


        //rb.MovePosition(rb.position + forwardMove+horizontalMove);

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

                //rb.AddForce(Vector3.right * horizontalSpeed, ForceMode.Force);
                //gameObject.transform.position += new Vector3(0.2f, 0,0);
            }
            if (Input.GetKey("a"))
            {
                rb.velocity += Vector3.left * horizontalSpeed;
                horizontalBrake = false;
                if (speed > 15)
                {
                    speed -= 7f * Time.deltaTime;
                }

                //gameObject.transform.position += new Vector3(-0.2f, 0, 0);

                //rb.AddForce(Vector3.left*horizontalSpeed, ForceMode.Force);
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

