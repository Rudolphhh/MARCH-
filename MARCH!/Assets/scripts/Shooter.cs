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
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }

        Destroy(bullet, bulletLifeTime);
    }
}
