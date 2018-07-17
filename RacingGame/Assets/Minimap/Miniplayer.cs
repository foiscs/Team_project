using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miniplayer : MonoBehaviour {

    public GameObject Car;
    Vector3 M;
    Quaternion S;
    
    // Update is called once per frame
    void Update()
    {
        M = new Vector3(Car.transform.position.x, 134f, Car.transform.position.z);
         transform.position = M;
    }
}
