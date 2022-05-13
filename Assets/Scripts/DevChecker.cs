using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevChecker : MonoBehaviour
{
    [SerializeField] Canvas DevCanvas;
    [SerializeField] Canvas PlayerCanvas;
    [SerializeField] Canvas HostCanvas;
    // Start is called before the first frame update
    void Start()
    {
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
