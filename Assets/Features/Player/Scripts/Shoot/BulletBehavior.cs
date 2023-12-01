using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 60f; // Mermi hızı
    public int hitCountToDestroyFlame = 3; // Alevi yok etmek için gereken isabet sayısı

    private Rigidbody rb;

    private static Dictionary<GameObject, int>
        flameHitCounts = new Dictionary<GameObject, int>(); // Alev nesnelerinin isabet sayılarını tutar

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed; // Mermiyi ileri doğru hızlandır
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flame"))
        {
            ProcessFlameHit(other.gameObject);
            gameObject.SetActive(false); // Mermiyi etkisiz hale getir
        }
    }

    private void ProcessFlameHit(GameObject flameObject)
    {
        if (!flameHitCounts.ContainsKey(flameObject))
        {
            flameHitCounts[flameObject] = 0;
        }

        flameHitCounts[flameObject]++;

        if (flameHitCounts[flameObject] >= hitCountToDestroyFlame)
        {
            Destroy(flameObject);
            flameHitCounts.Remove(flameObject);
            ScoreManager.Instance.AddScore(50);
        }
    }
}
