using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class ChangeScene : MonoBehaviour
{
    
    public void ChangeToScene(int sceneNum)
    {
        GameObject.Find("OrigCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("ConnectingCanvas").GetComponent<Canvas>().enabled = true;
        PhotonNetwork.JoinRandomRoom();
    }
}
