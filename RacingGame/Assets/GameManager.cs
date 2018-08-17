using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Photon.PunBehaviour
{
    public Miniplayer miniplayer;
    public ArrowScp arrow;
    public Speedmeter speedmeter;

    public List<GameObject> carPrefab = new List<GameObject>();
    public List<Transform> spawnPos = new List<Transform>();
    public void Awake()
    {
        //PhotonNetwork.Instantiate(this.carPrefab[PlayerPrefs.GetInt("car")].name)
    }

    public void SetCar(GameObject temp)
    {
        miniplayer.Car = temp;
        arrow.target = temp;
        speedmeter.vehicle = temp;
        speedmeter.Start();
    }
}
