using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParkingController : MonoBehaviour
{
    public bool IsParked { get; private set; }
    private CarMovementController _carMovement;

    void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        _carMovement = GetComponent<CarMovementController>();
    }

    public void ToggleParking()
    {
        IsParked = !IsParked;
        _carMovement.ApplyBrakes(IsParked);
    }
}