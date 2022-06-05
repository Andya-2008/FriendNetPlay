using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ActuateRobot : MonoBehaviour
{
    PhotonView photonView;
    private bool translateRight;
    private bool translateLeft;
    private bool ClawButton;
    [SerializeField] float moveSpeed = 100f;
    AutoDisconnectManager autoDisconnect;
    // Start is called before the first frame update
    void Start()
    {
        autoDisconnect = GameObject.Find("AutoDisconnectManager").GetComponent<AutoDisconnectManager>();
        //autoDisconnect.autoStartTime = Time.time;
        photonView = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (translateLeft) {
            TranslateLeft();
        }
        if (translateRight)
        {
            TranslateRight();
        }
    }

    public void buttonDown(string controllerType, string buttonType)
    {
        photonView.RPC("buttonDownRPC", RpcTarget.MasterClient, controllerType, buttonType);
    }


    public void buttonUp(string controllerType, string buttonType)
    {
        photonView.RPC("buttonUpRPC", RpcTarget.MasterClient, controllerType, buttonType);
    }


    [PunRPC]
    public void buttonDownRPC(string controllerType, string buttonType)
    {
        autoDisconnect.autoStartTime = Time.time;
        if (controllerType == "MoverController")
        {
            if (buttonType == "ButtonRight")
            {
                translateRight = true;
            }
            if (buttonType == "ButtonLeft")
            {
                translateLeft = true;
            }
        }
        if (controllerType == "ClawController")
        {
            if (buttonType == "Button")
            {
                GameObject.Find("Claw").GetComponent<CloseClaw>().ClawButton = true;
            }
        }
        if(controllerType == "PivotController1")
        {
            if(buttonType == "ButtonRight")
            {
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateRight = true;
            }
            if (buttonType == "ButtonLeft")
            {
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateLeft = true;
            }
        }    
        if(controllerType == "PivotController2")
        {
            if (buttonType == "ButtonRight")
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateRight = true;
            }
            if (buttonType == "ButtonLeft")
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateLeft = true;
            }
            if (buttonType == "ButtonUp")
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().contractUp = true;
            }
            if (buttonType == "ButtonDown")
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().extendDown = true;
            }
        }
    }

    [PunRPC]
    public void buttonUpRPC(string controllerType, string buttonType)
    {
        autoDisconnect.autoStartTime = Time.time;
        if (controllerType == "MoverController")
        {
            if (buttonType == "ButtonRight")
            {
                translateRight = false;
            }
            if (buttonType == "ButtonLeft")
            {
                translateLeft = false;
            }
        }
        if (controllerType == "ClawController")
        {
            if (buttonType == "Button")
            {
                GameObject.Find("Claw").GetComponent<CloseClaw>().ClawButton = false;
            }
        }
        if (controllerType == "PivotController1")
        {
            if (buttonType == "ButtonRight")
            {
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateRight = false;
            }
            if (buttonType == "ButtonLeft")
            {
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateLeft = false;
            }
        }
        if (controllerType == "PivotController2")
        {
            if (buttonType == "ButtonRight")
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateRight = false;
            }
            if (buttonType == "ButtonLeft")
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateLeft = false;
            }
            if (buttonType == "ButtonUp")
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().contractUp = false;
            }
            if (buttonType == "ButtonDown")
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().extendDown = false;
            }
        }


    }


    void TranslateRight()
    {
        GameObject wholeRobot = GameObject.Find("RobotMover");
        if (wholeRobot.transform.position.x <= 7.34)
            wholeRobot.transform.Translate(moveSpeed / 100 * Time.deltaTime, 0, 0);
    }
    void TranslateLeft()
    {
        GameObject wholeRobot = GameObject.Find("RobotMover");
        if (wholeRobot.transform.position.x >= -7.34)
            wholeRobot.transform.Translate(-1 * moveSpeed / 100 * Time.deltaTime, 0, 0);
    }
}
