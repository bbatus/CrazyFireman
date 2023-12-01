using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CarData 
{
    public float maxSteerAngle = 30f;
    public float torque = 200f;
    public float brakeTorque = 1000f;
    public Transform centerOfMass;
}
