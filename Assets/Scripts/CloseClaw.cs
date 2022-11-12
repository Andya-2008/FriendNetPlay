using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseClaw : MonoBehaviour
{
    float startTime;
    [SerializeField] GameObject Claw1;
    [SerializeField] GameObject Claw2;
    public bool ClawClosingBool = false;
    public bool ClawOpenBool;
    public bool ClawStallBool1;
    public bool ClawStallBool2;
    public bool BallInPlace=false;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject Ball;
    public bool dontTime;
    public bool ClawButton;
    public float lastClawChangeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        lastClawChangeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //if lastClawChangeTime is within 1 second, then don't do anything.
        // ClawStallBool1 is when the left side is touching the ball.  ClawStallBool2 is when right side is touching the ball.
        
            //This is when the claw has the ball.
            if (ClawButton && ClawStallBool1 && ClawStallBool2)
            {
                ClawOpenBool = true;
                ClawStallBool1 = false;
                ClawStallBool2 = false;

            }
            else if (ClawButton || ClawClosingBool)
            {
                ClawClosingBool = true;
                ClawGrab();
            }


        if (ClawStallBool1 && ClawStallBool2 && ClawClosingBool && BallInPlace)
        {
            
                Ball.transform.parent = GameObject.Find("BallAttached").transform;
                Ball.GetComponent<Rigidbody2D>().isKinematic = true;
                Ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                ClawClosingBool = false;
                ClawOpenBool = false;
            
        }


            // If ClawOpenBool is true and the claws have not opened all the way, then the jaws open.
            if (Claw1.transform.localRotation.eulerAngles.z > 300 && ClawOpenBool)
            {
                ClawOpen();
                ClawClosingBool = false;
            if (Time.time - lastClawChangeTime > .5)
            {
                lastClawChangeTime = Time.time;
                Vector2 vel = Ball.GetComponent<Rigidbody2D>().velocity;
                Ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Ball.GetComponent<Rigidbody2D>().isKinematic = false;
                Ball.transform.parent = GameObject.Find("FreeBall").transform;
                //Debug.Log(vel);
                Ball.GetComponent<Rigidbody2D>().velocity = vel;
            }
            }
            // this happens after the claw opens all the way.
            else if (Claw1.transform.localRotation.eulerAngles.z <= 300)
            {
                ClawOpenBool = false;
            }

    }

    private void ClawGrab()
    {
        Claw1.transform.Rotate(0, 0, moveSpeed * Time.deltaTime * 100);
        Claw2.transform.Rotate(0, 0, -1*moveSpeed*Time.deltaTime*100);
    }
    public void ClawOpen()
    {
        Claw1.transform.Rotate(0, 0, -1*moveSpeed*Time.deltaTime*100);
        Claw2.transform.Rotate(0, 0, moveSpeed*Time.deltaTime*100);
    }
}
