using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedmeter : MonoBehaviour {

    static float maxagl= -133.39f;
    static float minagl= 132.8f;
    static Speedmeter thisSpeed;
    public GameObject vehicle;
    public Text SpeedTx;
    public Text GearTx;
    public float rpm;
    public float Cs;
    

    public Rigidbody PlayerRb;
	void Start () {
        thisSpeed = this;
        rpm = vehicle.GetComponent<Drivetrain>().rpm - 1000f;

    }

    void Update()
    {
        Cs = PlayerRb.GetComponent<Rigidbody>().velocity.magnitude*3.6f;
        rpm = vehicle.GetComponent<Drivetrain>().rpm - 1000f;
        ShowSpeed(rpm/100, 0, 100);
        SpeedTx.text = "" + (int)Cs;//+"Km";
        ShowGear();
        //GearTx.text = "" + vehicle.GetComponent<Drivetrain>().gear;
    }

    public static void ShowSpeed(float speed,float min,float max)
    {
        float ang = Mathf.Lerp(minagl, maxagl, Mathf.InverseLerp(min, max, speed));
        thisSpeed.transform.eulerAngles = new Vector3(0, 0, ang);
    }

    void ShowGear()
    {
        if(vehicle.GetComponent<Drivetrain>().gear==1)
        {
            GearTx.text = "N";
        }

        else
        {
           int gr= vehicle.GetComponent<Drivetrain>().gear-1;
            GearTx.text = "" + gr;
        }
    }
	
	

}
