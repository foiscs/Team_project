﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Horizontal" + Input.GetAxis("Horizontal"));
        Debug.Log("Vertical" + Input.GetAxis("Vertical"));
    }
}
