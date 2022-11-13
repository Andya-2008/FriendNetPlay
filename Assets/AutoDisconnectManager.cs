using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class AutoDisconnectManager : MonoBehaviourPunCallbacks
{
    private float lastTimeConnect = 0;
    private float ReConnectInterval = 15;
    // Start is called before the first frame update
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.IsConnected  && (Time.time - lastTimeConnect > ReConnectInterval))
        {
            lastTimeConnect = Time.time;
            Debug.Log("Disconnected");
            if (PlayerPrefs.GetString("PlayerType")=="Host")
            {
                PhotonNetwork.ConnectUsingSettings();
            }
        }


    }
    public override void OnConnectedToMaster()
    {
        if (PlayerPrefs.GetString("PlayerType") == "Host")
        {
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnJoinedLobby()
    {
        // whenever this joins a new lobby, clear any previous room lists
        Debug.Log("Joined Lobby");
        if (PlayerPrefs.GetString("PlayerType") == "Host")
        {
            RoomOptions options = new RoomOptions { MaxPlayers = 8 };

            string roomName = PlayerPrefs.GetString("RoomCode");
            PhotonNetwork.CreateRoom(roomName, options, null);
            
        }
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created");
        PhotonNetwork.JoinRoom(PlayerPrefs.GetString("RoomCode"));
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room Joined");
        PhotonNetwork.LoadLevel("Clawooperation");
    }
    /*
    [PunRPC]
    void LogOut()
    {
        PhotonNetwork.LoadLevel("Menu");
    }
        if (PlayerPrefs.GetString("PlayerType") == "Dev")
        {
            if (Time.time - autoStartTime >= 60 && !alreadyLoaded)
            {
                alreadyLoaded = true;
                GameObject.Find("GameOverManager").GetComponent<GameOverManager>().CallLogOut();
}

        }
    */
}
