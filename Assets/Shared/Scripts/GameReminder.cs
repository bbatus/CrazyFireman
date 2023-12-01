using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameReminder : MonoBehaviour
{
    public Text introText; 
    private readonly string[] messages = {
        "Hoşgeldin İtfaiyeci! Şehrin sana ihtiyacı var!",
        "WASD tuşları ile arabayı kullanıp park alanlarına aracı park etmelisin!",
        "E tuşu ile araçtan in ve tüm alevleri söndürüp şehre yardım et!"
    };
    void Start()
    {
        StartCoroutine(ShowIntroMessages());
    }
    
    IEnumerator ShowIntroMessages()
    {
        foreach (var message in messages)
        {
            introText.text = message;
            yield return new WaitForSeconds(2); 
        }

        introText.gameObject.SetActive(false); 
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1); 
    }
}
