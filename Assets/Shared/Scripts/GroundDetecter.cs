using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetecter : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // Hareketi durdur
                rb.angularVelocity = Vector3.zero; // Dönmeyi durdur
            }
        }
    }
}
