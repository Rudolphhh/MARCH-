using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    private Health health;

    public bool isInTrench = false;
    public bool isGoingForward = true;
    public bool isGoingBackward = false;
    [SerializeField]
    public int speed;

    public Vector3 direction = new Vector3(1, 0, 0);
    
    // Start is called before the first frame update
    public void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (health.isAlive == true)
        {
            if (!isInTrench)
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
            }


            if (isGoingBackward)
            {
                direction = new Vector3(-direction.x, direction.y, direction.z);
                transform.Rotate(0, 180, 0);
            }
        }
        
        
    }
}
