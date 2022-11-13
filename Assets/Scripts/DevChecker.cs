using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DevChecker : MonoBehaviour
{
    [SerializeField] Canvas DevCanvas;
    [SerializeField] Canvas PlayerCanvas;
    [SerializeField] Canvas HostCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("My Nickname:" + PhotonNetwork.LocalPlayer.NickName);
        Debug.LogError("First Player Nickname:" + PhotonNetwork.PlayerList[0].NickName);
        if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[0].NickName)
        {
            DevCanvas.GetComponent<Canvas>().enabled = true;
            HostCanvas.GetComponent<Canvas>().enabled = false;
            PlayerCanvas.GetComponent<Canvas>().enabled = false;
        }
        else {
            PlayerPrefs.SetString("PlayerType", "Player");
        }
        /*
        if(PlayerPrefs.GetString("PlayerType") == "Dev")
        {
            DevCanvas.GetComponent<Canvas>().enabled = true;
            HostCanvas.GetComponent<Canvas>().enabled = false;
            PlayerCanvas.GetComponent<Canvas>().enabled = false;
        }
        
        if(PlayerPrefs.GetString("PlayerType") == "Host")
        {
            HostCanvas.GetComponent<Canvas>().enabled = true;
            DevCanvas.GetComponent<Canvas>().enabled = false;
            PlayerCanvas.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            PlayerCanvas.GetComponent<Canvas>().enabled = true;
            HostCanvas.GetComponent<Canvas>().enabled = false;
            DevCanvas.GetComponent<Canvas>().enabled = false;
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
