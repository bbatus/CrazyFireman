using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMechanism : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float delayBeforeExplosion = 1.5f; // Bombanın patlamasına kadar geçecek süre
    public ParticleSystem explosionEffect; // Patlama efekti için Particle System

    void Start() {
        // Bombanın patlama sürecini başlat
        StartCoroutine(ExplodeAfterDelay());
    }

    IEnumerator ExplodeAfterDelay() {
        // Belirtilen süre kadar bekle
        yield return new WaitForSeconds(delayBeforeExplosion);
        
        // Patlama efektini tetikle
        if (explosionEffect != null) {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Explode();
    }

    void Explode() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders) {
            if (hitCollider.CompareTag("Flame")) {
                Destroy(hitCollider.gameObject);
            }
        }
        // Bombayı yok et
        Destroy(gameObject);
        ScoreManager.Instance.AddScore(500);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}