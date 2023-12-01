using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarDetection : MonoBehaviour
{
    public Text crashText; // Kaza metni için UI Text referansı
    public Text parkText; // Park başarısı metni için UI Text referansı

    private void Start()
    {
        if (crashText != null) 
        {
            crashText.gameObject.SetActive(false); // Başlangıçta kaza text'ini gizle
        }
        if (parkText != null) 
        {
            parkText.gameObject.SetActive(false); // Başlangıçta park text'ini gizle
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("House"))
        {
            ScoreManager.Instance.SubtractScore(50);
            ShowCrashWarning();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Park"))
        {
            Debug.Log("Park alanına girildi");
            ScoreManager.Instance.AddScore(100);
            ShowParkSuccessMessage();
        }
    }

    void ShowCrashWarning()
    {
        if (crashText != null)
        {
            crashText.text = "Çarptığınız için -50 puan";
            crashText.gameObject.SetActive(true);
            Invoke("HideCrashWarning", 2f); // 2 saniye sonra gizle
        }
    }

    void HideCrashWarning()
    {
        if (crashText != null)
        {
            crashText.gameObject.SetActive(false);
        }
    }

    void ShowParkSuccessMessage()
    {
        if (parkText != null)
        {
            parkText.text = "Park alanına park yaptığınız için +100 puan";
            parkText.gameObject.SetActive(true);
            Invoke("HideParkSuccessMessage", 2f); // 2 saniye sonra gizle
        }
    }

    void HideParkSuccessMessage()
    {
        if (parkText != null)
        {
            parkText.gameObject.SetActive(false);
        }
    }
}