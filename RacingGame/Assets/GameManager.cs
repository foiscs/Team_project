using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Miniplayer miniplayer;
    public ArrowScp arrow;
    public Speedmeter speedmeter;

    public void SetCar(GameObject temp)
    {
        miniplayer.Car = temp;
        arrow.target = temp;
        speedmeter.vehicle = temp;
        speedmeter.Start();
    }
}
