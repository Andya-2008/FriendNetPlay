using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviour
{
    PhotonView photonView;
    [SerializeField] GameObject ButtonLeft;
    [SerializeField] GameObject ButtonRight;
    [SerializeField] GameObject ButtonDown;
    [SerializeField] GameObject ButtonUp;
    [SerializeField] float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        photonView = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ButtonLeft.GetComponent<MyButton>().buttonPressed)
        {
            MoveLeft();
        }
        if (ButtonRight.GetComponent<MyButton>().buttonPressed)
        {
            MoveRight();
        }
        if (ButtonUp.GetComponent<MyButton>().buttonPressed)
        {
            MoveUp();
        }
        if (ButtonDown.GetComponent<MyButton>().buttonPressed)
        {
            MoveDown();
        }
    }

    public void MoveLeft()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Left");
    }
    public void MoveRight()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Right");
    }
    public void MoveUp()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Up");
    }
    public void MoveDown()
    {
        photonView.RPC("Move", RpcTarget.MasterClient, "Down");
    }

    [PunRPC]

    void Move(string dir)
    {
        if (dir == "Left")
        {
            GameObject.Find("TestSphere").GetComponent<Rigidbody>().AddForce(-1 * transform.right * moveSpeed);
        }
        else if (dir == "Right")
        {
            GameObject.Find("TestSphere").GetComponent<Rigidbody>().AddForce(transform.right * moveSpeed);
        }
        else if (dir == "Up")
        {
            GameObject.Find("TestSphere").GetComponent<Rigidbody>().AddForce(transform.forward*moveSpeed);
        }
        else if (dir == "Down")
        {
            GameObject.Find("TestSphere").GetComponent<Rigidbody>().AddForce(-1 * transform.forward*moveSpeed);
        }
    }


}
