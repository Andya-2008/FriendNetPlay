using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LoadAllGames : MonoBehaviour
{
    PhotonView photonView;
    // Start is called before the first frame update
    void Awake()
    {
        photonView = PhotonView.Get(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonLoadGame()
    {
        photonView.RPC("LoadGame", RpcTarget.All);
    }

    [PunRPC]
    void LoadGame()
    {
        GameObject.Find("MainPanel").GetComponent<LobbyMainPanel>().alreadySetHost = false;
        GameObject.Find("MainPanel").GetComponent<LobbyMainPanel>().alreadyJoined = false;
        SceneManager.LoadScene("Clawooperation");
        //PhotonNetwork.LoadLevel("Clawooperation");

    }
    
}
