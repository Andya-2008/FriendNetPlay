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
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject Ball;
    public bool dontTime;
    public bool ClawButton;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Delete this later
        
        if (ClawButton && ClawStallBool1 && ClawStallBool2)
        {
            dontTime = false;
            startTime = Time.time;
            ClawOpenBool = true;
            ClawStallBool1 = false;
            ClawStallBool2 = false;

        }
        else if (ClawButton || ClawClosingBool)
        {
            ClawClosingBool = true;
            ClawGrab();
        }
        if (ClawStallBool1&&ClawStallBool2)
        {
            dontTime = true;
            if (Time.time - startTime >= .5f)
            {
                Ball.transform.parent = GameObject.Find("BallAttached").transform;
                Ball.GetComponent<Rigidbody2D>().isKinematic = true;
                Ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                ClawClosingBool = false;
                ClawOpenBool = false;
            }
            else
            {
                ClawOpenBool = true;
                ClawStallBool1 = false;
                ClawStallBool2 = false;
            }
        }
        if(Claw1.transform.localRotation.eulerAngles.z > 300 && ClawOpenBool)
        {
            Ball.transform.parent = GameObject.Find("FreeBall").transform;
            Ball.GetComponent<Rigidbody2D>().isKinematic = false;
            Ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            ClawClosingBool = false;
            ClawOpen();
        }
        else if (Claw1.transform.localRotation.eulerAngles.z <= 300)
        {
            ClawOpenBool = false;
        }
        

    }

    private void ClawGrab()
    {
        Claw1.transform.Rotate(0, 0, moveSpeed);
        Claw2.transform.Rotate(0, 0, -1*moveSpeed);
    }
    public void ClawOpen()
    {
        Claw1.transform.Rotate(0, 0, -1*moveSpeed);
        Claw2.transform.Rotate(0, 0, moveSpeed);
    }
}
