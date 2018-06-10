using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour {

    public GameObject Line;
    public List<Transform> track;

    WheelCollider asd;
    public int trackNum;

	void Start ()
    {
        Transform[] line = Line.GetComponentsInChildren<Transform>(); //자기자신까지 집어넣음
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] != Line.transform) //자기 자신 제외
            {
                track.Add(line[i]);
            }
        }
    }

	void Update ()
    {
       
	}
}
