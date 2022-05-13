using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LoadAllGames : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonLoadGame()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("LoadGame", RpcTarget.All);
    }

    [PunRPC]
    void LoadGame()
    {
        PhotonNetwork.LoadLevel("Clawooperation");
    }
    
}
