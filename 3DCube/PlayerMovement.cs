using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1000f;
    public Rigidbody rb;
    public float sideForce = 2000f;
    public float jumpForce = 2000f;
    Vector3 start = new Vector3(0.0f, 1.0f, 0f);
    Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);


    //setting event variables
    public bool right = false;
    public bool left = false;
    public bool jump = false;
    public bool jumping = false;






    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // if (Input.GetMouseButtonDown(0))
       // {
        //    rb.rotation = Quaternion.Euler(new Vector3(15, 5, 10));


       // }

        if (Input.GetKey("d"))
        {
            right = true;
        }
        if (Input.GetKey("a"))
        {
            left = true;
        }
        if (Input.GetKey("w"))
        {
            jump = true;
        }


        if (jump)
        {
            moveUp();
        }
        if (right)
        {
            moveRight();
        }
        if (left)
        {
            moveLeft();
        }

        if (rb.position.y < 1.2 && rb.position.y > 0)
        {
            jumping = false;
        }

        if (rb.position.y<-1)
        {
            //rb.MovePosition(start);
            //rb.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //rb.velocity = zero;
            FindObjectOfType<GameManager>().EndGame();


        }

        rb.AddForce(0, 0, speed*Time.deltaTime);
    }

    private void moveRight()
    {
        rb.AddForce(sideForce*Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        right = false;
    }
    private void moveLeft()
    {
        rb.AddForce(-sideForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        left = false;
    }
    private void moveUp()
    {
        if (jumping)
        {
            //Debug.Log("currently jumping...");

        }
        else
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0);
            jump = false;
            jumping = true;
        }
       
    }


}
