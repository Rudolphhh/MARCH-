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
    public SoldierMovement soldierMovemnt;
    public AudioSource audioSource;
    public AudioClip shootingSound;

    [SerializeField]
    private GameObject shootEffectPrefab; // Reference to the particle effect prefab

    private float bulletLifeTime = 6f;
    [SerializeField]
    private float reloadTime = 2f;

    private bool isShooting = false; // Tracks if the soldier is currently shooting
    private int originalSpeed; // To store the soldier's speed before shooting

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Detect single press of spacebar
        {
            isShooting = !isShooting; // Toggle shooting state

            if (isShooting)
            {
                StartShooting();
            }
            else
            {
                StopShooting();
            }
        }
    }

    void StartShooting()
    {
        
        originalSpeed = soldierMovemnt.speed;

        
        soldierMovemnt.speed *= 0;

        
        StartCoroutine(ShootingCoroutine());
    }

    void StopShooting()
    {
        
        soldierMovemnt.speed = originalSpeed;

        
        StopAllCoroutines();
    }

    IEnumerator ShootingCoroutine()
    {
        while (isShooting)
        {
            Shoot();
            yield return new WaitForSeconds(reloadTime); // Wait for the reload time between shots
        }
    }

    void Shoot()
    {
        audioSource.Play();

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Instantiate particle effect at the firePoint position
        Instantiate(shootEffectPrefab, firePoint.position, firePoint.rotation);

        // Add force to the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }

        // Destroy the bullet after its lifetime
        Destroy(bullet, bulletLifeTime);
    }
}
