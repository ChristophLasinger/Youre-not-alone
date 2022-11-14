using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class LobbyMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject backgroundImage;

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        menuPanel.SetActive(false);
        backgroundImage.SetActive(false);
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
        menuPanel.SetActive(false);
        backgroundImage.SetActive(false);
    }
}
