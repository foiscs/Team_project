using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingWheel : MonoBehaviour
{

    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        //Debug.Log(Input.GetAxis("Vertical"));
        //Debug.LogFormat("x power {0}    y power {1}",Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        Debug.Log(Input.GetAxis("Fire1"));
    }
}
