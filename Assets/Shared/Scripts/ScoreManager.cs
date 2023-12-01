using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    public Text scoreText;
    private int score;
    public Text messageText; 
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
        
        if (amount == 300) 
        {
            ShowMessage("Kediyi kurtardığınız için 300 puan kazandınız");
        }
    }

    public void SubtractScore(int amount)
    {
        score -= amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
    
    private void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            messageText.gameObject.SetActive(true);
            Invoke("HideMessage", 3f); 
        }
    }
    
    private void HideMessage()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }
}



