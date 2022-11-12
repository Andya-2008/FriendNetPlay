using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PivotController1 : MonoBehaviour
{
    PhotonView photonView;
    [SerializeField] GameObject ButtonLeft;
    [SerializeField] GameObject ButtonRight;
    // Start is called before the first frame update
    void Start()
    {
        photonView = this.GetComponent<PhotonView>();
        /*
        ButtonLeft.GetComponent<MyButton>().controllerType = "PivotController1";
        ButtonLeft.GetComponent<MyButton>().buttonType = "ButtonLeft";
        ButtonRight.GetComponent<MyButton>().controllerType = "PivotController1";
        ButtonRight.GetComponent<MyButton>().buttonType = "ButtonRight";
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (ButtonLeft.GetComponent<MyButton>().buttonPressed)
        {
            MoveLeft();
        }
        else if (!ButtonLeft.GetComponent<MyButton>().buttonPressed)
        {
            MoveLeftDisabled();
        }
        if (ButtonRight.GetComponent<MyButton>().buttonPressed)
        {
            MoveRight();
        }
        else
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
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateLeft = true;
            }
            else
            {
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateLeft = false;
            }

        }



        if (dir == "Right")
        {
            if (enabled)
            {
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateRight = true;
            }
            else
            {
                GameObject.Find("Pivot1").GetComponent<PivotAndExtend>().rotateRight = false;
            }

        }
    }


}