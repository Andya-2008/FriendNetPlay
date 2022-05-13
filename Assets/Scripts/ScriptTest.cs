using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTest : MonoBehaviour
{
    public void Start()
    {
        Debug.Log(PlayerPrefs.GetString("PlayerName"));
    }
    
}
