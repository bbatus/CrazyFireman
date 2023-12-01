using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputController : MonoBehaviour
{
    private CarMovementController _carMovement;
    private CarParkingController _carParking;

    void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        _carMovement = GetComponent<CarMovementController>();
        _carParking = GetComponent<CarParkingController>();
    }

    void Update()
    {
        HandleParkingInput();
        HandleDrivingInput();
    }

    private void HandleDrivingInput()
    {
        if (!_carParking.IsParked)
        {
            float throttle = Input.GetAxis("Vertical");
            float steer = Input.GetAxis("Horizontal");
            _carMovement.Move(throttle, steer);
        }
        else
        {
            _carMovement.ApplyBrakes(true);
        }
    }

    private void HandleParkingInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _carParking.ToggleParking();
        }
    }
}