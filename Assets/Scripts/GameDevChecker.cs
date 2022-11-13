using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class GameDevChecker : MonoBehaviour
{
    [SerializeField] Canvas DevCanvas;
    [SerializeField] Canvas PlayerCanvas;
    [SerializeField] GameObject DevCamera;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] TMP_Text txtRoomCode;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("My Nickname:" + PhotonNetwork.LocalPlayer.NickName);
        Debug.Log("First Player Nickname:" + PhotonNetwork.PlayerList[0].NickName);
        if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[0].NickName)
        {
            DevCanvas.GetComponent<Canvas>().enabled = true;
            PlayerCanvas.GetComponent<Canvas>().enabled = false;
            DevCamera.SetActive(true);
            PlayerCamera.SetActive(false);
            txtRoomCode.text = "Room Code:" + PlayerPrefs.GetString("RoomCode");
        }
        else
        {
            PlayerCanvas.GetComponent<Canvas>().enabled = true;
            DevCanvas.GetComponent<Canvas>().enabled = false;
            PlayerCamera.SetActive(true);
            DevCamera.SetActive(false);
        }

        /*
        if (PlayerPrefs.GetString("PlayerType") == "Dev")
        {
            
            DevCanvas.GetComponent<Canvas>().enabled = true;
            PlayerCanvas.GetComponent<Canvas>().enabled = false;
            DevCamera.SetActive(true);
            PlayerCamera.SetActive(false);
        }
        else
        {
            PlayerCanvas.GetComponent<Canvas>().enabled = true;
            DevCanvas.GetComponent<Canvas>().enabled = false; 
            PlayerCamera.SetActive(true);
            DevCamera.SetActive(false);

        }
        */
        
    }

}
