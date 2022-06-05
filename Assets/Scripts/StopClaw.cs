using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopClaw : MonoBehaviour
{
    float startTime;
    [SerializeField] GameObject Claw1;
    [SerializeField] GameObject Claw2;
    [SerializeField] GameObject FullClaw;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.time - startTime >= .2f && !FullClaw.GetComponent<CloseClaw>().dontTime)
        {
            startTime = Time.time;
            GameObject.Find("Claw").GetComponent<CloseClaw>().ClawStallBool2 = false;
            GameObject.Find("Claw").GetComponent<CloseClaw>().ClawStallBool1 = false;
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameObject.Find("Claw").GetComponent<CloseClaw>().ClawOpenBool)
        {
            if (collision.gameObject.tag == "Ball")
            {
                if (Claw1 == this.gameObject)
                {
                    GameObject.Find("Claw").GetComponent<CloseClaw>().ClawStallBool1 = true;
                }
                if (Claw2 == this.gameObject)
                {
                    GameObject.Find("Claw").GetComponent<CloseClaw>().ClawStallBool2 = true;
                }
                
            }
            if (Claw1 == this.gameObject)
            {
                if (collision.gameObject == Claw2)
                {
                    GameObject.Find("Claw").GetComponent<CloseClaw>().ClawOpenBool = true;
                }
            }
            if (Claw2 == this.gameObject)
            {
                if (collision.gameObject == Claw1)
                {
                    GameObject.Find("Claw").GetComponent<CloseClaw>().ClawOpenBool = true;
                }
            }
        }
    }
}
