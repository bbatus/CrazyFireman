using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossRoadController : MonoBehaviour
{
    public Text crossRoadText;
    
    private void Start()
    {
        if (crossRoadText != null) 
        {
            crossRoadText.gameObject.SetActive(false); // Başlangıçta geçiş text'ini gizle
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OldGuy"))
        {
            //Debug.Log("Yaşlı adam başarıyla yola geçti!");
            
            ScoreManager.Instance.AddScore(500);
            ShowCrossRoadSuccessMessage();
        }
    }
    
    void ShowCrossRoadSuccessMessage()
    {
        if (crossRoadText != null)
        {
            crossRoadText.text = "Yaşlı adamı karşıya geçirdiğiniz için +500 puan";
            crossRoadText.gameObject.SetActive(true);
            Invoke("HideCrossRoadSuccessMessage", 2f); // 2 saniye sonra gizle
        }
    }

    void HideCrossRoadSuccessMessage()
    {
        if (crossRoadText != null)
        {
            crossRoadText.gameObject.SetActive(false);
        }
    }
}