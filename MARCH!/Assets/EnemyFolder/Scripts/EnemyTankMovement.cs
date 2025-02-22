using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    private EnemyTankHealth TankHealth;

    [SerializeField]
    public float speed;

    public Vector3 direction = new Vector3(-1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        TankHealth = GetComponent<EnemyTankHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TankHealth.isAlive)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}
