using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarTexts : MonoBehaviour
{
    public Text parkingWarningText;
    public CarParkingController carParkingController;

    void Start()
    {
        if (parkingWarningText != null) {
            parkingWarningText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !carParkingController.IsParked)
        {
            ShowParkingWarning();
        }
    }
    
    void ShowParkingWarning()
    {
        if (parkingWarningText != null)
        {
            parkingWarningText.text = "Araçtan inebilmek için önce park etmelisiniz (P)";
            parkingWarningText.gameObject.SetActive(true);

            // Belirli bir süre sonra uyarıyı gizle
            Invoke("HideParkingWarning", 5f);
        }
    }
    
    void HideParkingWarning()
    {
        if (parkingWarningText != null)
        {
            parkingWarningText.gameObject.SetActive(false);
        }
    }
}