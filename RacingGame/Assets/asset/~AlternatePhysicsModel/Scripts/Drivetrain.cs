using UnityEngine;
using System.Collections;

// This class simulates a car's engine and drivetrain, generating
// torque, and applying the torque to the wheels.
public class Drivetrain : MonoBehaviour {
	
	// All the wheels the drivetrain should power
	public Wheel[] poweredWheels;
	
	// The gear ratios, including neutral (0) and reverse (negative) gears
	public float[] gearRatios;
	
	// The final drive ratio, which is multiplied to each gear ratio
	public float finalDriveRatio = 3.23f;
	
	// The engine's torque curve characteristics. Since actual curves are often hard to come by,
	// we approximate the torque curve from these values instead.

	// powerband RPM range
	public float minRPM = 800;
	public float maxRPM = 6400;

	// engine's maximal torque (in Nm) and RPM.
	public float maxTorque = 664;
	public float torqueRPM = 4000;

	// engine's maximal power (in Watts) and RPM.
	public float maxPower = 317000;
	public float powerRPM = 5000;

	// engine inertia (how fast the engine spins up), in kg * m^2
	public float engineInertia = 0.3f;
	
	// engine's friction coefficients - these cause the engine to slow down, and cause engine braking.

	// constant friction coefficient
	public float engineBaseFriction = 25f;
	// linear friction coefficient (higher friction when engine spins higher)
	public float engineRPMFriction = 0.02f;

	// Engine orientation (typically either Vector3.forward or Vector3.right). 
	// This determines how the car body moves as the engine revs up.	
	public Vector3 engineOrientation = Vector3.right;
	
	// Coefficient determining how muchg torque is transfered between the wheels when they move at 
	// different speeds, to simulate differential locking.
	public float differentialLockCoefficient = 0;
	
	// inputs
	// engine throttle
	public float throttle = 0;
	// engine throttle without traction control (used for automatic gear shifting)
	public float throttleInput = 0;

    //clutch
    public float clutch;
    private float clutchTorque;
    

	// shift gears automatically?
	public bool automatic = true;

	// state
	public int gear = 2;
	public float rpm;
	public float slipRatio = 0.0f;
	float engineAngularVelo;

    public Turbocharger turbo;
    public bool enableTurbo = false;

	
	float Sqr (float x) { return x*x; }
	
	// Calculate engine torque for current rpm and throttle values.
	float CalcEngineTorque () 
	{
		float result;
		if(rpm < torqueRPM)
			result = maxTorque*(-Sqr(rpm / torqueRPM - 1) + 1);
		else {
			float maxPowerTorque = maxPower/(powerRPM*2*Mathf.PI/60);
			float aproxFactor = (maxTorque-maxPowerTorque)/(2*torqueRPM*powerRPM-Sqr(powerRPM)-Sqr(torqueRPM));
			float torque = aproxFactor * Sqr(rpm-torqueRPM)+maxTorque;
			result=torque>0?torque:0;
		} 
		if(rpm > maxRPM)
		{
			result *= 1-((rpm-maxRPM) * 0.006f);
			if(result<0)
				result=0;
		}
		if(rpm<0)
			result=0;
		return result;
	}
    private void Awake()
    {
        if(enableTurbo)
        {
            //turbo.
        }
    }

    void FixedUpdate () 
	{
		float ratio = gearRatios[gear] * finalDriveRatio;
		float inertia = engineInertia * Sqr(ratio);
		float engineFrictionTorque = engineBaseFriction + rpm * engineRPMFriction;
		float engineTorque = (CalcEngineTorque() + Mathf.Abs(engineFrictionTorque)) * throttle;
		slipRatio = 0.0f;		
		
		if (ratio == 0)
		{
			// Neutral gear - just rev up engine
			float engineAngularAcceleration = (engineTorque-engineFrictionTorque) / engineInertia;
			engineAngularVelo += engineAngularAcceleration * Time.deltaTime;
			
			// Apply torque to car body
			GetComponent<Rigidbody>().AddTorque(-engineOrientation * engineTorque);
		}
		else
		{
			float drivetrainFraction = 1.0f/poweredWheels.Length;
			float averageAngularVelo = 0;	
			foreach(Wheel w in poweredWheels)
				averageAngularVelo += w.angularVelocity * drivetrainFraction;

			// Apply torque to wheels
			foreach(Wheel w in poweredWheels)
			{
				float lockingTorque = (averageAngularVelo - w.angularVelocity) * differentialLockCoefficient;
				w.drivetrainInertia = inertia * drivetrainFraction;
				w.driveFrictionTorque = engineFrictionTorque * Mathf.Abs(ratio) * drivetrainFraction;
				w.driveTorque = engineTorque * ratio * drivetrainFraction + lockingTorque;

				slipRatio += w.slipRatio * drivetrainFraction;
			}
			
			// update engine angular velo
			engineAngularVelo = averageAngularVelo * ratio;
		}
		
		// update state
		slipRatio *= Mathf.Sign ( ratio );
		rpm = engineAngularVelo * (60.0f/(2*Mathf.PI));
		
		// very simple simulation of clutch - just pretend we are at a higher rpm.
		float minClutchRPM = minRPM;
		if (gear == 2)
			minClutchRPM += throttle * 3000;
		if (rpm < minClutchRPM)
			rpm = minClutchRPM;
			
		// Automatic gear shifting. Bases shift points on throttle input and rpm.
		if (automatic)
		{
			if (rpm >= maxRPM * (0.5f + 0.5f * throttleInput))
				ShiftUp ();
			else if (rpm <= maxRPM * (0.25f + 0.4f * throttleInput) && gear > 2)
				ShiftDown ();
			if (throttleInput < 0 && rpm <= minRPM)
				gear = (gear == 0?2:0);
		}
	}
		
	public void ShiftUp () {
		if (gear < gearRatios.Length - 1)
			gear ++;
	}

	public void ShiftDown () {
		if (gear > 0)
			gear --;
	}
	
    [System.Serializable]
    public class Turbocharger
    {
        public float angularVelocity = 0f;
        public float prevAngularVelocity = 0f;
        public float brakingCoeff = 0.92f;

        public float rpm = 0f;
        private float maxRpm = 8000f;
        private float rpmNormalized = 0f;

        public float boost = 2f;
        public float pressure = 0f;
        [HideInInspector]
        public float prev_pressure = 0f;

        private AudioSource WhistleSource;
        public AudioClip WhistleSound;

        private AudioSource blowOffSource;
        public AudioClip blowOffSound;

        [HideInInspector]
        public float prev_throttle;
        public bool isSteeringWheelNo2 = false;

        public void SetWhistleAudio(AudioSource s)
        {
            if(!WhistleSound)
                Debug.LogError("no turbo whistle sound!");

            s.playOnAwake = true;
            s.loop = true;
            s.priority = 0;
            s.clip = WhistleSound;
            s.spatialBlend = 1f;
            s.dopplerLevel = 0f;
            s.Play();

            WhistleSource = s;
        }

        public void SetBlowOffAudio(AudioSource s)
        {
            if (!blowOffSound)
                Debug.LogError("no turbo blow off sound!");

            s.playOnAwake = false;
            s.loop = false;
            s.priority = 0;
            s.clip = blowOffSound;
            s.spatialBlend = 1f;
            s.dopplerLevel = 0f;
            
            blowOffSource = s;
        }

        public float CalculateTorque(float engineRpmNormalized, float throttle)
        {
            float inertia = 0.0f;

            float angularAcceleration = throttle * engineRpmNormalized * 300f / inertia;
            angularVelocity += angularAcceleration * Time.deltaTime;
            angularVelocity += -brakingCoeff * rpmNormalized * 60f;

            rpm = angularVelocity * 60f;//rpm

            rpmNormalized = rpm / maxRpm;

            prev_pressure = pressure;
            pressure = rpmNormalized * boost * throttle + (isSteeringWheelNo2 ? 3.5f : 0f);

            CalculateBlowOff(throttle, prev_pressure);

            WhistleSource.pitch = engineRpmNormalized;
            WhistleSource.volume = rpmNormalized * 0.2f;

            return pressure * boost * 0.1f;
        }

        public void CalculateBlowOff(float throttle, float pressure)
        {
            prevAngularVelocity = angularVelocity;

            if (pressure > (isSteeringWheelNo2 ? 10.5f : 11.5f) && throttle <=
                (isSteeringWheelNo2 ? 0.6f : 0))
            {
                if(!blowOffSource.isPlaying)
                {
                    blowOffSource.volume = rpmNormalized * 0.13f - (isSteeringWheelNo2 ? 0.375f : 0.075f);
                    blowOffSource.pitch = pressure / (boost * 8f) + 0.176f;
                    blowOffSource.Play();

                    angularVelocity = 0f;
                }
                else
                {
                    blowOffSource.volume = rpmNormalized * 0.13f - (isSteeringWheelNo2 ? 0.375f : 0.075f);
                    blowOffSource.pitch = pressure / (boost * 0.8f) + 0.176f;
                    blowOffSource.Stop();
                    blowOffSource.Play();
                }
            }
        }
    }
	// Debug GUI. Disable when not needed.
	void OnGUI () {
		GUILayout.Label("RPM: "+rpm);
		GUILayout.Label("Gear: "+(gear-1));
		automatic = GUILayout.Toggle(automatic, "Automatic Transmission");
	}
}
