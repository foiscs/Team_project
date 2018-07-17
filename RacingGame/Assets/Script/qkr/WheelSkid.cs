using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSkid : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Skidmarks skidmarksController;

    Wheel wheel;

    const float SKID_FX_SPEED = 0.5F;
    const float MAX_SKID_INTENSITY = 20.0F;
    const float WHEEL_SLIP_MULTIPLIER = 1.0F;
    int lastSkide = -1;

    private void Awake()
    {
        wheel = GetComponent<Wheel>();
        skidmarksController = GameObject.Find("skidmarkmanager").GetComponent<Skidmarks>();
    }
    private void LateUpdate()
    {
        if (wheel.onGround)
        {
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            float skidTotal = Mathf.Abs(localVelocity.x);

            float wheelAngularVelocity = wheel.radius * ((2 * Mathf.PI * wheel.rotation) / 60);
            float carForwardVel = Vector3.Dot(rb.velocity, transform.forward);
            float wheelSpin = Mathf.Abs(carForwardVel - wheelAngularVelocity) * WHEEL_SLIP_MULTIPLIER;

            wheelSpin = Mathf.Max(0, wheelSpin * (10 - carForwardVel));

            skidTotal += wheelSpin;

            if (skidTotal >= SKID_FX_SPEED)
            {
                float intensity = Mathf.Clamp01(skidTotal / MAX_SKID_INTENSITY);
                Vector3 skidPoint = wheel.hit.point + (rb.velocity * Time.fixedDeltaTime);
                lastSkide = skidmarksController.AddSkidMark(skidPoint, wheel.hit.normal, intensity, lastSkide);

            }
            else
                lastSkide = -1;
        }
        else
            lastSkide = -1;
    }
}
