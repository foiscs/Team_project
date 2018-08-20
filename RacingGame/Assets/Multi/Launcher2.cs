using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Launcher2 : Photon.PunBehaviour
{
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene(1);
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1");
    }
}
