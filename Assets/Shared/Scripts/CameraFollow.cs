using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public Transform target; // Takip edilecek hedef
    public Vector3 offset; // Hedef ile kamera arasındaki sabit mesafe
    public float smoothSpeed = 0.500f; 
    public float rotationSpeed = 5f; // Kamera dönme hızı

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Hedefe doğru yumuşak bir şekilde dönme
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}