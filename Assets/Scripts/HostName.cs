using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun.Demo.Asteroids;
using Photon.Pun;

public class HostName : MonoBehaviour
{
    //public string hostName;
    //[SerializeField] GameObject hostText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            /*if (PhotonNetwork.CountOfPlayers >= 2)
            {
                hostText.SetActive(true);
            }
            else
            {
                hostText.SetActive(false);
            }*/
        this.GetComponent<TextMeshProUGUI>().text = GameObject.Find("MainPanel").GetComponent<LobbyMainPanel>().hostName.ToString() + " is host!";
    }
}
