using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanism : MonoBehaviour
{
    public GameObject waterBulletPrefab;
    public Transform firePoint;
    public int maxBullets = 10;
    public float bulletSpeed = 60f; // Mermi hızı
    
    public GameObject bombPrefab;
    public int maxBombs = 3;
    public int bombCount;

    private Queue<GameObject> bulletsPool;

    private void Awake()
    {
        bombCount = maxBombs;
    }

    void Start()
    {
        
        bulletsPool = new Queue<GameObject>();

        for (int i = 0; i < maxBullets; i++)
        {
            GameObject bullet = Instantiate(waterBulletPrefab, firePoint.localPosition, Quaternion.identity);
            bullet.SetActive(false);
            bulletsPool.Enqueue(bullet);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.B) && bombCount > 0)
        {
            ThrowBomb();
        }
    }
    
    private void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * 15f, ForceMode.Impulse); // Bombaya hız ver (değer ayarlanabilir)
        bombCount--;
    }

    void Fire()
    {
        if (bulletsPool.Count > 0)
        {
            GameObject bullet = bulletsPool.Dequeue();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
            
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * bulletSpeed; // Mermiye hızını tekrar ata

            StartCoroutine(DeactivateBulletAfterTime(bullet, 3));
        }
    }

    IEnumerator DeactivateBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (bullet.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.velocity = Vector3.zero; // Hızı sıfırla
            rb.angularVelocity = Vector3.zero; // Açısal hızı sıfırla
        }

        bullet.SetActive(false);
        bulletsPool.Enqueue(bullet);
    }
    
    // public int RemainingBullets()
    // {
    //     return bulletsPool.Count;
    // }

    public int RemainingBombs()
    {
        return bombCount;
    }
    
}