using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;
    [SerializeField] GameObject MainObjects;
    float countdown;
    bool Initiated = false;
    bool alreadyLoaded = false;
    [SerializeField] GameObject LevelText;
    // Start is called before the first frame update
    void Start()
    {
        Initiated = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Initiated)
        {
            if(Time.time-countdown > 10 && !alreadyLoaded)
            {
                alreadyLoaded = true;
                CallLogOut();
            }
        }
    }
    public void GameOverInitiate()
    {
        //PhotonNetwork.Disconnect();
        Initiated = true;
        countdown = Time.time;
        GameOverCanvas.GetComponent<Canvas>().enabled = true;
        LevelText.SetActive(false);
        MainObjects.SetActive(false);
    }

    public void CallLogOut()
    {
        this.GetComponent<PhotonView>().RPC("LogOut", RpcTarget.All);
    }
    [PunRPC]
    void LogOut()
    {
        PhotonNetwork.LoadLevel("Menu");
    }
}
