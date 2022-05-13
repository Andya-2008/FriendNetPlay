using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SavePlayerName : MonoBehaviour
{
    
    public void SaveThePlayerName(TextMeshProUGUI InputFieldText)
    {
        PlayerPrefs.SetString("PlayerName", InputFieldText.text);
    }
}
