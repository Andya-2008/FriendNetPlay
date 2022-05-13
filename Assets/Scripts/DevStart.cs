using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DevStart : MonoBehaviour
{
    bool alreadyCreatedRoom = false;
    [SerializeField] GameObject origCanvas;
    [SerializeField] GameObject devCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        //(Right Ctrl + Right Shift + D + E + V) will start game
        if(!alreadyCreatedRoom && Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.V))
        {
            devCanvas.GetComponent<Canvas>().enabled = true;
            origCanvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
