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
    public EnemyMovement EnemysoldierMovemnt;
    public AudioSource audioSource;
    public AudioClip shootingSound;

    [SerializeField]
    private GameObject shootEffectPrefab; // Reference to the particle effect prefab

    private float bulletLifeTime = 6f;
    private float reloadTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Shoot", 0f, reloadTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        audioSource.Play();
        if (EnemysoldierMovemnt.isGoingForward == true)
        {
            EnemysoldierMovemnt.isGoingForward = false;
            EnemysoldierMovemnt.speed = 0;
        }
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
