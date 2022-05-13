using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotAndExtend : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] int pivotPlayer;
    [SerializeField] float scaleSpeed=1f;
    [SerializeField] GameObject ScaleSquare;
    [SerializeField] GameObject PivotP2;
    public bool rotateLeft;
    public bool rotateRight;
    public bool extendDown;
    public bool contractUp;

    bool alreadyScaled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pivotPlayer == 1)
        {
            //Fix rotation NOW
            if (rotateLeft)
            {
                if ((this.transform.rotation.eulerAngles.z >= 300))
                {
                    RawPivot("Left");
                }
                if((Mathf.RoundToInt(this.transform.rotation.eulerAngles.z) >= 0 && this.transform.rotation.eulerAngles.z <= 65))
                {
                    RawPivot("Left");
                }
            }
            if (rotateRight)
            {
                if ((this.transform.rotation.eulerAngles.z <= 360 && this.transform.rotation.eulerAngles.z >= 295))
                {
                    RawPivot("Right");
                }
                if (this.transform.rotation.eulerAngles.z <= 60)
                {
                    RawPivot("Right");
                }
            }

        }
        if (pivotPlayer == 2)
        {
            if (rotateLeft)
            {
                if ((this.transform.localRotation.eulerAngles.z >= 330))
                {
                    RawPivot("Left");
                }
                if ((Mathf.RoundToInt(this.transform.localRotation.eulerAngles.z) >= 0 && this.transform.localRotation.eulerAngles.z <= 35))
                {
                    RawPivot("Left");
                }
            }
            if (rotateRight)
            {
                
                if ((this.transform.localRotation.eulerAngles.z <= 360 && this.transform.localRotation.eulerAngles.z >= 325))
                {
                    RawPivot("Right");
                }
                if (this.transform.localRotation.eulerAngles.z <= 30)
                {
                    RawPivot("Right");
                }
            }
        }
        /*if (pivotPlayer == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                RawExtend();
                PivotP2.transform.position += new Vector3(0, -1 * scaleSpeed / 20, 0);
            }
            
        }*/
        if (pivotPlayer == 2)
        {
            if (extendDown && ScaleSquare.transform.position.y >= -.4)
            {
                RawExtend();
                PivotP2.transform.position += transform.up * -1 * scaleSpeed / 20*Time.deltaTime;
            }
            else if(contractUp && ScaleSquare.transform.position.y <= 1)
            {
                RawContract();
                PivotP2.transform.position += transform.up * scaleSpeed / 20*Time.deltaTime;
            }

        }
    }
    void RawExtend()
    {
        ScaleSquare.transform.localScale += new Vector3(0, scaleSpeed/20*Time.deltaTime, 0);
        //ScaleSquare.transform.position += new Vector3(0, -1 * scaleSpeed / 40, 0);
        ScaleSquare.transform.position += transform.up * -1 * scaleSpeed / 40*Time.deltaTime;
    }
    void RawContract()
    {
        ScaleSquare.transform.localScale -= new Vector3(0, scaleSpeed / 20*Time.deltaTime, 0);
        ScaleSquare.transform.position += transform.up * scaleSpeed / 40*Time.deltaTime;
    }
    void RawPivot(string dir)
    {
        if(dir == "Left")
        {
            this.transform.Rotate(0, 0, turnSpeed * -1*Time.deltaTime);
        }
        if(dir == "Right")
        {
            this.transform.Rotate(0, 0, turnSpeed*Time.deltaTime);
        }
    }
}
