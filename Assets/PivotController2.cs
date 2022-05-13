using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PivotController2 : MonoBehaviour
{
    PhotonView photonView;
    [SerializeField] GameObject ButtonLeft;
    [SerializeField] GameObject ButtonRight;
    [SerializeField] GameObject ButtonUp;
    [SerializeField] GameObject ButtonDown;
    // Start is called before the first frame update
    void Start()
    {
        photonView = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
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
        else if(!ButtonRight.GetComponent<MyButton>().buttonPressed)
        {
            MoveRightDisabled();
        }

        /*if (ButtonUp.GetComponent<MyButton>().buttonPressed)
        {
            MoveUp();
        }
        else if (!ButtonUp.GetComponent<MyButton>().buttonPressed)
        {
            MoveUpDisabled();
        }
        if (ButtonDown.GetComponent<MyButton>().buttonPressed)
        {
            MoveDown();
        }
        else if (!ButtonDown.GetComponent<MyButton>().buttonPressed)
        {
            MoveDownDisabled();
        }*/
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
    /*public void MoveUp()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Up", true);
    }
    public void MoveDown()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Down", true);
    }
    public void MoveUpDisabled()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Up", false);
    }
    public void MoveDownDisabled()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Down", false);
    }*/

    [PunRPC]

    void Move(string dir, bool enabled)
    {
        if (dir == "Left")
        {
            if (enabled)
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateLeft = true;
            }
            else
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateLeft = false;
            }

        }



        if (dir == "Right")
        {
            if (enabled)
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateRight = true;
            }
            else
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().rotateRight = false;
            }

        }
        /*if (dir == "Up")
        {
            if (enabled)
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().contractUp = true;
            }
            else
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().contractUp = false;
            }

        }



        if (dir == "Down")
        {
            if (enabled)
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().extendDown = true;
            }
            else
            {
                GameObject.Find("Pivot2").GetComponent<PivotAndExtend>().extendDown = false;
            }

        }*/
    }


}