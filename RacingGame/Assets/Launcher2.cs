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
    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
