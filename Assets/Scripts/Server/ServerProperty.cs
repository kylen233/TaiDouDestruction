using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerProperty : MonoBehaviour
{
    public Text text_serverName;

    public string serverName
    {
        set { text_serverName.text = value; }
        get { return serverName; }
    }
    public int count;
    public string ipaddress;

  
}
