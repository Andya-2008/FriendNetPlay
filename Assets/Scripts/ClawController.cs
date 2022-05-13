using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class ClawController : MonoBehaviour
{
    PhotonView photonView;
    [SerializeField] GameObject CenterButton;
    // Start is called before the first frame update
    void Start()
    {
        photonView = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CenterButton.GetComponent<MyButton>().buttonPressed)
        {
            ClawButton();
        }
        else
        {
            ClawButtonRelease();
        }
    }

    private void ClawButtonRelease()
    {
        photonView.RPC("Close", RpcTarget.MasterClient, false);
    }

    public void ClawButton()
    {
        photonView.RPC("Close", RpcTarget.MasterClient, true);
    }




    [PunRPC]
    void Close(bool pressed)
    {
        if(pressed)
        {
            GameObject.Find("Claw").GetComponent<CloseClaw>().ClawButton = true;
        }
        else if(!pressed)
        {
            GameObject.Find("Claw").GetComponent<CloseClaw>().ClawButton = false;
        }
        
    }
}
