using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerRoleRandomizer : MonoBehaviour
{
    [SerializeField] GameObject btnLeft;
    [SerializeField] GameObject btnRight;
    [SerializeField] GameObject btnUp;
    [SerializeField] GameObject btnDown;
    [SerializeField] GameObject btnLeftHinge1;
    [SerializeField] GameObject btnRightHinge1;
    [SerializeField] GameObject btnLeftHinge2;
    [SerializeField] GameObject btnRightHinge2;
    [SerializeField] GameObject btnClaw;

    public int numOfPlayers;

    // Start is called before the first frame update
    void Start()
    {

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
                        btnLeft.SetActive(true);
                        btnRight.SetActive(true);
                        btnUp.SetActive(false);
                        btnDown.SetActive(false);
                        btnLeftHinge1.SetActive(false);
                        btnRightHinge1.SetActive(false);
                        btnLeftHinge2.SetActive(false);
                        btnRightHinge2.SetActive(false);
                        btnClaw.SetActive(true);
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[2].NickName)
                    {
                        btnLeft.SetActive(false);
                        btnRight.SetActive(false);
                        btnUp.SetActive(true);
                        btnDown.SetActive(true);
                        btnLeftHinge1.SetActive(false);
                        btnRightHinge1.SetActive(false);
                        btnLeftHinge2.SetActive(false);
                        btnRightHinge2.SetActive(false);
                        btnClaw.SetActive(true);
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[3].NickName)
                    {
                        btnLeft.SetActive(false);
                        btnRight.SetActive(false);
                        btnUp.SetActive(false);
                        btnDown.SetActive(false);
                        btnLeftHinge1.SetActive(true);
                        btnRightHinge1.SetActive(true);
                        btnLeftHinge2.SetActive(false);
                        btnRightHinge2.SetActive(false);
                        btnClaw.SetActive(true);
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[4].NickName)
                    {
                        btnLeft.SetActive(false);
                        btnRight.SetActive(false);
                        btnUp.SetActive(false);
                        btnDown.SetActive(false);
                        btnLeftHinge1.SetActive(false);
                        btnRightHinge1.SetActive(false);
                        btnLeftHinge2.SetActive(true);
                        btnRightHinge2.SetActive(true);
                        btnClaw.SetActive(true);
                    }
                }
                if (PhotonNetwork.PlayerList.Length == 4)
                {
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[1].NickName)
                    {
                        btnLeft.SetActive(true);
                        btnRight.SetActive(true);
                        btnUp.SetActive(false);
                        btnDown.SetActive(false);
                        btnLeftHinge1.SetActive(false);
                        btnRightHinge1.SetActive(false);
                        btnLeftHinge2.SetActive(false);
                        btnRightHinge2.SetActive(false);
                        btnClaw.SetActive(true);
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[2].NickName)
                    {
                        btnLeft.SetActive(false);
                        btnRight.SetActive(false);
                        btnUp.SetActive(true);
                        btnDown.SetActive(true);
                        btnLeftHinge1.SetActive(false);
                        btnRightHinge1.SetActive(false);
                        btnLeftHinge2.SetActive(false);
                        btnRightHinge2.SetActive(false);
                        btnClaw.SetActive(true);
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[3].NickName)
                    {
                        btnLeft.SetActive(false);
                        btnRight.SetActive(false);
                        btnUp.SetActive(false);
                        btnDown.SetActive(false);
                        btnLeftHinge1.SetActive(true);
                        btnRightHinge1.SetActive(true);
                        btnLeftHinge2.SetActive(true);
                        btnRightHinge2.SetActive(true);
                        btnClaw.SetActive(true);
                    }
                }
                if (PhotonNetwork.PlayerList.Length == 3)
                {
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[1].NickName)
                    {
                        btnLeft.SetActive(true);
                        btnRight.SetActive(true);
                        btnUp.SetActive(true);
                        btnDown.SetActive(true);
                        btnLeftHinge1.SetActive(false);
                        btnRightHinge1.SetActive(false);
                        btnLeftHinge2.SetActive(false);
                        btnRightHinge2.SetActive(false);
                        btnClaw.SetActive(true);
                    }
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[2].NickName)
                    {
                        btnLeft.SetActive(false);
                        btnRight.SetActive(false);
                        btnUp.SetActive(false);
                        btnDown.SetActive(false);
                        btnLeftHinge1.SetActive(true);
                        btnRightHinge1.SetActive(true);
                        btnLeftHinge2.SetActive(true);
                        btnRightHinge2.SetActive(true);
                        btnClaw.SetActive(true);
                    }
                }
                if (PhotonNetwork.PlayerList.Length == 2)
                {
                    if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[1].NickName)
                    {
                        btnLeft.SetActive(true);
                        btnRight.SetActive(true);
                        btnUp.SetActive(true);
                        btnDown.SetActive(true);
                        btnLeftHinge1.SetActive(true);
                        btnRightHinge1.SetActive(true);
                        btnLeftHinge2.SetActive(true);
                        btnRightHinge2.SetActive(true);
                        btnClaw.SetActive(true);
                    }
                }
            }
        }
    }
}
