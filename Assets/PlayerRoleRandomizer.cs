using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerRoleRandomizer : MonoBehaviour
{
    [SerializeField] Canvas MoverCanvas4;
    [SerializeField] Canvas PivotCanvas14;
    [SerializeField] Canvas PivotCanvas24;
    [SerializeField] Canvas ClawCanvas4;
    [SerializeField] Canvas MoverCanvas3;
    [SerializeField] Canvas PivotCanvas13;
    [SerializeField] Canvas PivotCanvas23;
    [SerializeField] Canvas MoverCanvas2;
    [SerializeField] Canvas PivotCanvas12;

    public int numOfPlayers;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            numOfPlayers = PhotonNetwork.PlayerList.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (numOfPlayers != PhotonNetwork.PlayerList.Length)
            {
                numOfPlayers = PhotonNetwork.PlayerList.Length;
                if (PhotonNetwork.PlayerList.Length == 5)
                {
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[1].NickName)
                    {
                        MoverCanvas4.GetComponent<Canvas>().enabled = true;
                        PivotCanvas14.GetComponent<Canvas>().enabled = false;
                        PivotCanvas24.GetComponent<Canvas>().enabled = false;
                        ClawCanvas4.GetComponent<Canvas>().enabled = false;
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[2].NickName)
                    {
                        MoverCanvas4.GetComponent<Canvas>().enabled = false;
                        PivotCanvas14.GetComponent<Canvas>().enabled = true;
                        PivotCanvas24.GetComponent<Canvas>().enabled = false;
                        ClawCanvas4.GetComponent<Canvas>().enabled = false;
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[3].NickName)
                    {
                        MoverCanvas4.GetComponent<Canvas>().enabled = false;
                        PivotCanvas14.GetComponent<Canvas>().enabled = false;
                        PivotCanvas24.GetComponent<Canvas>().enabled = true;
                        ClawCanvas4.GetComponent<Canvas>().enabled = false;
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[4].NickName)
                    {
                        MoverCanvas4.GetComponent<Canvas>().enabled = false;
                        PivotCanvas14.GetComponent<Canvas>().enabled = false;
                        PivotCanvas24.GetComponent<Canvas>().enabled = false;
                        ClawCanvas4.GetComponent<Canvas>().enabled = true;
                    }
                }
                if (PhotonNetwork.PlayerList.Length == 4)
                {
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[1].NickName)
                    {
                        MoverCanvas3.GetComponent<Canvas>().enabled = true;
                        PivotCanvas13.GetComponent<Canvas>().enabled = false;
                        PivotCanvas23.GetComponent<Canvas>().enabled = false;
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[2].NickName)
                    {
                        MoverCanvas3.GetComponent<Canvas>().enabled = false;
                        PivotCanvas13.GetComponent<Canvas>().enabled = true;
                        PivotCanvas23.GetComponent<Canvas>().enabled = false;
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[3].NickName)
                    {
                        MoverCanvas3.GetComponent<Canvas>().enabled = false;
                        PivotCanvas13.GetComponent<Canvas>().enabled = false;
                        PivotCanvas23.GetComponent<Canvas>().enabled = true;
                    }
                }
                if (PhotonNetwork.PlayerList.Length == 3)
                {
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[1].NickName)
                    {
                        MoverCanvas2.GetComponent<Canvas>().enabled = true;
                        PivotCanvas12.GetComponent<Canvas>().enabled = false;
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[2].NickName)
                    {
                        MoverCanvas2.GetComponent<Canvas>().enabled = false;
                        PivotCanvas12.GetComponent<Canvas>().enabled = true;
                    }
                }
            }
        }
    }
}
