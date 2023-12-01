using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPickUp : MonoBehaviour
{
    public CharacterController characterController;
    public Transform holdPosition;
    public float pickupRange = 2f;
    public LayerMask pickupLayer;
    public float throwForce = 1f; // Yumuşak fırlatma kuvveti

    private GameObject heldObject = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }
    }

    void TryPickupObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, pickupLayer))
        {
            if (hit.collider.CompareTag("PickUp"))
            {
                heldObject = hit.collider.gameObject;
                heldObject.transform.SetParent(holdPosition);
                heldObject.transform.position = holdPosition.position;

                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                // Yumuşak fırlatma için kuvvet uygula
                rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
            }

            heldObject.transform.SetParent(null);
            heldObject = null;
            
            ScoreManager.Instance.AddScore(300);
        }
    }
    

}