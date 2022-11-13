using ExitGames.Client.Photon;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using TMPro;

public class NetworkPanelScript : MonoBehaviourPunCallbacks
{
    [Header("Inputs")]
    public InputField PlayerNameInput;

    [Header("Buttons")]
    public Button createButton;
    public Button LoginButton;
    public Button StartGameButton;
    

    [Header("Text")]
    public Text roomNameText;
    public Text roomCodeText;

    [Header("DropDown")]
    public TMP_Dropdown ddRoomList;

    [Header("Canvas")]
    public Canvas thisCanvas;


    [Header("Panels")]
    //public GameObject LoginPanel;
    //public GameObject SelectionPanel;
    //public GameObject CreateRoomPanel;
    public GameObject JoinRoomPanel;
    //public GameObject RoomListPanel;
    public GameObject MainPanel;
    public GameObject InsideRoomPanel;

    [Header("PreFabs")]
    public GameObject PlayerListEntryPrefab;
    public GameObject RoomButton;


    private Dictionary<int, GameObject> playerListEntries;
    public string hostName;



    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        

        PlayerNameInput.text = "Player " + Random.Range(1000, 10000);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Time.time - lastUpdate > 5)
        {
            Debug.Log("Update");
            lastUpdate = Time.time;
            Player[] players = PhotonNetwork.PlayerList;
            foreach (Player p in players)
            {
                Debug.Log(p.NickName);
            }
        }
        */
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        createButton.interactable = true;
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        // whenever this joins a new lobby, clear any previous room lists
        Debug.Log("Joined Lobby");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("Room List Updated:" + Time.time);

        if (roomList.Count > 0) {
            LoginButton.interactable = true;
        }

        GameObject roomListContent = GameObject.Find("RoomListContent");
        
        List<string> lstRoomCode = new List<string>();
        foreach (RoomInfo ri in roomList) {
            lstRoomCode.Add(ri.Name);
        }
        ddRoomList.AddOptions(lstRoomCode);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create Room Failed");
        Debug.Log(returnCode.ToString() + ":" + message);
        SetActivePanel(MainPanel.name);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Join Room Failed");
        Debug.Log(returnCode.ToString() + ":" + message);
        SetActivePanel(MainPanel.name);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed");
        SetActivePanel(MainPanel.name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

        Debug.Log("Player Entered Room");
        
        GameObject entry = Instantiate(PlayerListEntryPrefab);
        entry.transform.SetParent(InsideRoomPanel.transform);
        entry.transform.localScale = Vector3.one;
        //entry.GetComponent<PlayerListEntry>().Initialize(newPlayer.ActorNumber, newPlayer.NickName);

        playerListEntries.Add(newPlayer.ActorNumber, entry);
        

        StartGameButton.gameObject.SetActive(true);
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player Left Room");

        Destroy(playerListEntries[otherPlayer.ActorNumber].gameObject);
        playerListEntries.Remove(otherPlayer.ActorNumber);

        StartGameButton.gameObject.SetActive(true);
    }

    public void OnCreateRoomButtonClicked()
    {
        Debug.Log("CreateRoomButtonClicked");
        //GameObject.Find("OrigCanvas").GetComponent<Canvas>().enabled = false;
        //thisCanvas.GetComponent<Canvas>().enabled = true;
        string roomName = Random.Range(1000, 10000).ToString();
        PhotonNetwork.LocalPlayer.NickName = "Host Screen";
        RoomOptions options = new RoomOptions { MaxPlayers = 8 };
        PlayerPrefs.SetString("RoomCode", roomName);
        PlayerPrefs.SetString("PlayerType", "Host");
        PhotonNetwork.CreateRoom(roomName, options, null);
    }

    public void OnJoinRoomButtonClicked()
    {
        Debug.Log("JoinRoomButtonClicked");
        //SetActivePanel(JoinRoomPanel.name);
        string playerName = PlayerNameInput.text;
        if (!playerName.Equals(""))
        {
            Debug.Log("Join Room:" + ddRoomList.options[ddRoomList.value].text);
            PhotonNetwork.LocalPlayer.NickName = playerName;
            PhotonNetwork.JoinRoom(ddRoomList.options[ddRoomList.value].text);
        }
        else
        {
            Debug.LogError("Player Name is invalid.");
        }
        
    }

    public void OnStartGameButtonClicked()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("StartGame", RpcTarget.MasterClient);
        }
        else {
            StartGame();
        }
    }
    [PunRPC]
    public void StartGame()
    {

        //  Should we make the room no longer available after the game starts?
        //  Or can people join in any time?
        /*
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        */
        PhotonNetwork.LoadLevel("Clawooperation");
    }

    public override void OnJoinedRoom()
    {
        try
        {
            Debug.Log("Joined Room1");
            SetActivePanel(InsideRoomPanel.name);
            Debug.Log(PhotonNetwork.CurrentRoom.Name);
            roomNameText.GetComponent<Text>().text = PhotonNetwork.CurrentRoom.Name;

            //if (!devCheck)
            //{
            if (playerListEntries == null)
            {
                playerListEntries = new Dictionary<int, GameObject>();
            }

            foreach (Player p in PhotonNetwork.PlayerList)
            {
                /*
                    if (p == PhotonNetwork.PlayerList[1])
                    {
                        hostName = p.NickName;
                    }
                */
                GameObject entry = Instantiate(PlayerListEntryPrefab);
                entry.transform.SetParent(InsideRoomPanel.transform);
                entry.transform.localScale = Vector3.one;
                entry.GetComponent<PlayerListEntry>().Initialize(p.ActorNumber, p.NickName);

                object isPlayerReady;
                if (p.CustomProperties.TryGetValue(AsteroidsGame.PLAYER_READY, out isPlayerReady))
                {
                    entry.GetComponent<PlayerListEntry>().SetPlayerReady((bool)isPlayerReady);
                }

                playerListEntries.Add(p.ActorNumber, entry);
            }

            //}


            //StartGameButton.gameObject.SetActive(CheckPlayersReady());
            /*
            Hashtable props = new Hashtable
            {
                {AsteroidsGame.PLAYER_LOADED_LEVEL, false}
            };
            PhotonNetwork.LocalPlayer.SetCustomProperties(props);
            */
        }
        catch (System.Exception ex) {
            Debug.Log(ex.Message);
        }
    }

    private void SetActivePanel(string activePanel)
    {
        MainPanel.SetActive(activePanel.Equals(MainPanel.name));
        //LoginPanel.SetActive(activePanel.Equals(LoginPanel.name));
        //SelectionPanel.SetActive(activePanel.Equals(SelectionPanel.name));
        //CreateRoomPanel.SetActive(activePanel.Equals(CreateRoomPanel.name));
        //JoinRandomRoomPanel.SetActive(activePanel.Equals(JoinRandomRoomPanel.name));
        //RoomListPanel.SetActive(activePanel.Equals(RoomListPanel.name));    // UI should call OnRoomListButtonClicked() to activate this
        InsideRoomPanel.SetActive(activePanel.Equals(InsideRoomPanel.name));
    }

}
