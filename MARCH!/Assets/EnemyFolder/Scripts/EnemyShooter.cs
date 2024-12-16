using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    [SerializeField]
    private Transform firePoint;
    public AudioSource audioSource;
    public AudioClip shootingSound;

    [SerializeField]
    private GameObject shootEffectPrefab;

    private float bulletLifeTime = 6f;
    [SerializeField]
    private float reloadTime = 2f;

    private bool isReloading = false;

    
    [SerializeField] private EnemyMovement EnemyMovement;

    public void TryShoot()
    {
        if (!isReloading)
        {
            EnemyMovement.StartShooting();
            Shoot();
            StartCoroutine(ReloadCoroutine());
        }
    }

    private void Shoot()
    {
        
        if (audioSource != null && shootingSound != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }

        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        
        if (shootEffectPrefab != null)
        {
            Instantiate(shootEffectPrefab, firePoint.position, firePoint.rotation);
        }

        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }

        
        Destroy(bullet, bulletLifeTime);
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        EnemyMovement.StopShooting();
    }
}
