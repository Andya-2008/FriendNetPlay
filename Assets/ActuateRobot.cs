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
    void FixedUpdate()
    {
        if (translateLeft || Input.GetKey(KeyCode.A)) {
            TranslateLeft();
        }
        if (translateRight || Input.GetKey(KeyCode.D))
        {
            TranslateRight();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject.Find("Claw").GetComponent<CloseClaw>().ClawButton = true;
        }
        else
        {
            GameObject.Find("Claw").GetComponent<CloseClaw>().ClawButton = false;
        }
    }
    
    public void buttonDown(string cmd)
    {
        photonView.RPC("buttonRPC", RpcTarget.MasterClient, cmd, true);
    }


    public void buttonUp(string cmd)
    {
        photonView.RPC("buttonRPC", RpcTarget.MasterClient, cmd, false);
    }


    [PunRPC]
    public void buttonRPC(string cmd, bool blCmd)
    {
        autoDisconnect.autoStartTime = Time.time;
        switch (cmd) {
            case "Right":
                translateRight = blCmd;
                break;
            case "Left":
                translateLeft = blCmd;
                break;
            case "Claw":
                GameObject.Find("Claw").GetComponent<CloseClaw>().ClawButton = blCmd;
                break;
            case "RightHinge1":
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateRight = blCmd;
                break;
            case "LeftHinge1":
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateLeft = blCmd;
                break;
            case "RightHinge2":
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateRight = blCmd;
                break;
            case "LeftHinge2":
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateLeft = blCmd;
                break;
            case "Up":
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().contractUp = blCmd;
                break;
            case "Down":
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().extendDown = blCmd;
                break;
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
