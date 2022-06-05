using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerRoleRandomizer : MonoBehaviour
{
    [SerializeField] Canvas MoverCanvas;
    [SerializeField] Canvas PivotCanvas1;
    [SerializeField] Canvas PivotCanvas2;
    [SerializeField] Canvas ClawCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[1].NickName)
            {
                MoverCanvas.GetComponent<Canvas>().enabled = true;
                PivotCanvas1.GetComponent<Canvas>().enabled = false;
                PivotCanvas2.GetComponent<Canvas>().enabled = false;
                ClawCanvas.GetComponent<Canvas>().enabled = false;
            }
            if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[2].NickName)
            {
                MoverCanvas.GetComponent<Canvas>().enabled = false;
                PivotCanvas1.GetComponent<Canvas>().enabled = true;
                PivotCanvas2.GetComponent<Canvas>().enabled = false;
                ClawCanvas.GetComponent<Canvas>().enabled = false;
            }
            if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[3].NickName)
            {
                MoverCanvas.GetComponent<Canvas>().enabled = false;
                PivotCanvas1.GetComponent<Canvas>().enabled = false;
                PivotCanvas2.GetComponent<Canvas>().enabled = true;
                ClawCanvas.GetComponent<Canvas>().enabled = false;
            }
            if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[4].NickName)
            {
                MoverCanvas.GetComponent<Canvas>().enabled = false;
                PivotCanvas1.GetComponent<Canvas>().enabled = false;
                PivotCanvas2.GetComponent<Canvas>().enabled = false;
                ClawCanvas.GetComponent<Canvas>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
