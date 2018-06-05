using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    public WheelCollider FrontLeftWheel;
    public WheelCollider FrontRightWheel;

    public float[] GearRatio;
    public int CurrentGear = 0;

    public float EngineTorque = 230.0f;
    public float MaxEngineRPM = 3000.0f;
    public float MinEngineRPM = 1000.0f;

    private float EngineRPM = 0.0f;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().centerOfMass += new Vector3(0, -0.75f, 0.25f);
    }

    private void Update()
    {
        EngineRPM = (FrontLeftWheel.rpm + FrontRightWheel.rpm) / 2 * GearRatio[CurrentGear];
        ShiftGears();

        FrontLeftWheel.motorTorque = EngineTorque / GearRatio[CurrentGear] * Input.GetAxis("Vertical");
        FrontRightWheel.motorTorque = EngineTorque / GearRatio[CurrentGear] * Input.GetAxis("Vertical");

        FrontLeftWheel.steerAngle = 10 * Input.GetAxis("Horizontal");
        FrontRightWheel.steerAngle = 10 * Input.GetAxis("Horizontal");
    }

    private void ShiftGears()
    {
        int AppropriateGear = CurrentGear;
        if (EngineRPM >= MaxEngineRPM)
        {
            for (int i = 0; i < GearRatio.Length; i++)
            {
                if (FrontLeftWheel.rpm * GearRatio[i] < MaxEngineRPM)
                {
                    AppropriateGear = i;
                    break;
                }
            }
            CurrentGear = AppropriateGear;
        }
        if (EngineRPM <= MinEngineRPM)
        {
            AppropriateGear = CurrentGear;
            for (int j = GearRatio.Length - 1; j >= 0; j--) 
            {
                if(FrontLeftWheel.rpm * GearRatio[j]>MinEngineRPM)
                {
                    AppropriateGear = j;
                    break;
                }
            }
            CurrentGear = AppropriateGear;
        }
    }
}
