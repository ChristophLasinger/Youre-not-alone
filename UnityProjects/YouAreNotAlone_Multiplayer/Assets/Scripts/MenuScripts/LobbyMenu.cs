using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using UnityEngine.UI;
using MLAPI.Transports.UNET;
using System;

public class LobbyMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject backgroundImage;
    private string ipAddress = string.Empty;
    private string port = string.Empty;
    public InputField ipInputField;
    public InputField portInputField;

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        menuPanel.SetActive(false);
        backgroundImage.SetActive(false);
    }

    public void Join()
    {
        if(ipAddress != string.Empty && port != string.Empty)
        {
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = ipAddress;
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectPort = Int32.Parse(port);
            NetworkManager.Singleton.StartClient();
            menuPanel.SetActive(false);
            backgroundImage.SetActive(false);
        }
    }
    public void ReadUserIpAddress()
    {
        ipAddress = ipInputField.text;
        Debug.Log(ipAddress);
    }
    public void ReadUserPort()
    {
        port = portInputField.text;
        Debug.Log(port);
        
    }
}
