using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    [SerializeField]
    private Transform firePoint;
    public AudioSource audioSource;
    public AudioClip shootingSound;

    [SerializeField]
    private GameObject shootEffectPrefab; // Particle effect for shooting

    private float bulletLifeTime = 6f;
    [SerializeField]
    private float reloadTime = 2f; // Time between shots

    private bool isReloading = false; // Prevent shooting while reloading

    // Reference to the SoldierMovement script
    [SerializeField] private SoldierMovement soldierMovement;

    public void TryShoot()
    {
        if (!isReloading)
        {
            soldierMovement.StartShooting(); // Stop the soldier from moving when shooting
            Shoot();
            StartCoroutine(ReloadCoroutine());
        }
    }

    private void Shoot()
    {
        // Play shooting sound
        if (audioSource != null && shootingSound != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Instantiate particle effect
        if (shootEffectPrefab != null)
        {
            Instantiate(shootEffectPrefab, firePoint.position, firePoint.rotation);
        }

        // Add force to the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }

        // Destroy the bullet after its lifetime
        Destroy(bullet, bulletLifeTime);
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true; // Start reload
        yield return new WaitForSeconds(reloadTime); // Wait for reload time
        isReloading = false; // Allow shooting again
        soldierMovement.StopShooting(); // Start walking again after reloading
    }
}
