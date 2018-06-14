using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour {

    public GameObject Line;
    public List<Transform> track;

    public int trackNum;
    public Rigidbody car;

    public float maxSteerAngle = 60f;
    public WheelCollider WheelFR;
    public WheelCollider WheelFL;
    public float maxMotorTorque = 80f;
    public float currentSpeed;
    public float maxSpeed = 800f;
    public float newSteer;

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
        Debug.Log(track.Count);        
    }

	void FixedUpdate ()
    {
        WheelSteer();
        Drive();
        CheckTrack();
    }

    void WheelSteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(track[trackNum].position);
        newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        WheelFL.steerAngle = newSteer;
        WheelFR.steerAngle = newSteer;
    }

    void Drive()
    {
        currentSpeed = 10 * Mathf.PI * WheelFL.radius * WheelFL.rpm * 60 / 1000;

        if (currentSpeed < maxSpeed)
        {
            WheelFL.motorTorque = maxMotorTorque;
            WheelFR.motorTorque = maxMotorTorque;
        }
        else
        {
            WheelFL.motorTorque = 0;
            WheelFR.motorTorque = 0;
        }

    }

    void CheckTrack()
    {
        if (Vector3.Distance(transform.position, track[trackNum].position) < 3.0f)
        {
            if (trackNum == track.Count - 1)
            {
                trackNum = 0;
            }
            else
                trackNum++;
        }
    }
}
