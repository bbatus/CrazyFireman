using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    public CharacterController characterController;
    public float climbSpeed = 3f;
    public float raycastDistance = 2f;
    public LayerMask climbableLayer;

    private bool isClimbing = false;

    void Update()
    {
        if (!isClimbing)
        {
            CheckForClimb();
        }

        if (isClimbing)
        {
            HandleClimbing();
        }
    }

    void CheckForClimb()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, climbableLayer))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartClimbing();
            }
        }
    }

    void HandleClimbing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Climb(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Climb(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Climb(Vector3.down);
        }
        else
        {
            StopClimbing();
        }
    }

    void StartClimbing()
    {
        isClimbing = true;
        characterController.enabled = false;
    }

    void StopClimbing()
    {
        if (isClimbing)
        {
            isClimbing = false;
            characterController.enabled = true;
        }
    }

    void Climb(Vector3 direction)
    {
        transform.Translate(direction * climbSpeed * Time.deltaTime);
    }
}