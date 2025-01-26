using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private TankHealth TankHealth;

    [SerializeField]
    public float speed;

    public Vector3 direction = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        TankHealth = GetComponent<TankHealth>();
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
