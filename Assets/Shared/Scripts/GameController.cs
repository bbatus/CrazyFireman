using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public CarMovementController carMovementController;
    public CarParkingController carParkingController;
    public Camera carCamera; // Araba için olan kamera
    public GameObject playerPrefab; // Oyuncu prefabı
    public Transform playerExitPoint; 

    private GameObject currentPlayer;
    private bool isPlayerInCar = true;

    void Start()
    {
        // Başlangıçta araba kamerasını etkinleştir
        carCamera.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && carParkingController.IsParked)
        {
            if (isPlayerInCar)
            {
                ExitCar();
            }
            else
            {
                EnterCar();
            }
        }
    }

    private void ExitCar()
    {
        isPlayerInCar = false;
        carMovementController.enabled = false;

        currentPlayer = Instantiate(playerPrefab, playerExitPoint.position, playerExitPoint.rotation);
        currentPlayer.GetComponentInChildren<Camera>().enabled = true; // Oyuncu kamerasını etkinleştir
        carCamera.enabled = false; // Araba kamerasını devre dışı bırak
    }

    private void EnterCar()
    {
        isPlayerInCar = true;
        carMovementController.enabled = true;

        if (currentPlayer != null)
        {
            currentPlayer.GetComponentInChildren<Camera>().enabled = false; // Oyuncu kamerasını devre dışı bırak
            Destroy(currentPlayer); // Yaya karakterini sahneden kaldır
        }

        carCamera.enabled = true; // Araba kamerasını etkinleştir
    }
}
