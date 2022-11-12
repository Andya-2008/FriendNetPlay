
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MoverController : MonoBehaviour
{
    PhotonView photonView;
    [SerializeField] GameObject ButtonLeft;
    [SerializeField] GameObject ButtonRight;

    // Start is called before the first frame update
    void Start()
    {
        photonView = this.GetComponent<PhotonView>();
        /*
        ButtonLeft.GetComponent<MyButton>().controllerType = "MoverController";
        ButtonLeft.GetComponent<MyButton>().buttonType = "ButtonLeft";
        ButtonRight.GetComponent<MyButton>().controllerType = "MoverController";
        ButtonRight.GetComponent<MyButton>().buttonType = "ButtonRight";
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else {
            MoveLeftDisabled();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else
        {
            MoveRightDisabled();
        }
        /*
        if (ButtonLeft.GetComponent<MyButton>().buttonPressed)
        {
            MoveLeft();
        }
        else if (!ButtonLeft.GetComponent<MyButton>().buttonPressed )
        {
            MoveLeftDisabled();
        }

        if (ButtonRight.GetComponent<MyButton>().buttonPressed)
        {
            MoveRight();
        }
        else if()
        {
            MoveRightDisabled();
        }
        */
    }

    public void MoveLeft()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Left", true);
    }
    public void MoveRight()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Right", true);
    }
    public void MoveLeftDisabled()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Left", false);
    }
    public void MoveRightDisabled()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Right", false);
    }

    [PunRPC]

    void Move(string dir, bool enabled)
    {
        if (dir == "Left")
        {
            if (enabled)
            {
                Debug.LogError("Moving Left");
                GameObject.Find("RobotMover").GetComponent<RobotMoverScript>().moveLeft = true;
            }
            else
            {
                Debug.LogError("Stop moving left");
                GameObject.Find("RobotMover").GetComponent<RobotMoverScript>().moveLeft = false;
            }

        }



        if (dir == "Right")
        {
            if (enabled)
            {
                Debug.LogError("Moving Right");
                GameObject.Find("RobotMover").GetComponent<RobotMoverScript>().moveRight = true;
            }
            else
            {
                Debug.LogError("Stop moving Right");
                GameObject.Find("RobotMover").GetComponent<RobotMoverScript>().moveRight = false;
            }

        }
    }


}
