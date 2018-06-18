using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Replay : MonoBehaviour
{
    string savePath = @"C:\Users\HANSUNG\Documents\racing\test_file.txt";

    public List<TransfromInfo> tranfrominfo;
    public GameObject target;

    bool recording = false;
    void Start()
    {
        tranfrominfo = new List<TransfromInfo>();
    }

    void Update()
    {
        if (!recording && Input.GetKey(KeyCode.S))
        {
            Debug.Log("aa");
            recording = true;
            for (int i = 0; i < tranfrominfo.Count; i++)
            {
                using (StreamWriter outputFile = new StreamWriter(savePath, true))
                {
                    outputFile.WriteLine(tranfrominfo[i].Position);
                    outputFile.WriteLine(tranfrominfo[i].Rotation.eulerAngles);
                }
            }
        }
        else if (Input.GetKey(KeyCode.R))
            Record();

        else if (Input.GetKey(KeyCode.T))
        {

        }
    }

    void Record()
    {
        tranfrominfo.Add(new TransfromInfo(target.transform));
    }
    void Read()
    {

    }
}
