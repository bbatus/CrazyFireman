using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementController : MonoBehaviour
{
    public WheelCollider[] wheelColliders;
    public CarData carData;
    private Rigidbody CarRigidbody { get; set; }

    void Awake()
    {
        CarRigidbody = GetComponent<Rigidbody>();
        CarRigidbody.centerOfMass = carData.centerOfMass.localPosition;
    }

    public void Move(float throttle, float steerAngle)
    {
        steerAngle *= carData.maxSteerAngle;
        throttle *= carData.torque;

        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].motorTorque = throttle;
        }

        wheelColliders[0].steerAngle = steerAngle;
        wheelColliders[1].steerAngle = steerAngle;
    }

    public void ApplyBrakes(bool isParked)
    {
        float brakeForce = isParked ? carData.brakeTorque : 0f;
        foreach (WheelCollider wheel in wheelColliders)
        {
            wheel.brakeTorque = brakeForce;
        }
    }
}