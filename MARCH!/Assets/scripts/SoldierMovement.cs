using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    private Health health;
    private Rigidbody rb;

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
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (health.isAlive)
        {
            if (isInTrench)
            {
                
                rb.constraints = RigidbodyConstraints.FreezePositionX 
                    | RigidbodyConstraints.FreezePositionZ 
                    | RigidbodyConstraints.FreezePositionY 
                    | RigidbodyConstraints.FreezeRotation;
            }
            else
            {

                rb.constraints = RigidbodyConstraints.FreezePositionZ 
                    | RigidbodyConstraints.FreezePositionY 
                    | RigidbodyConstraints.FreezeRotation;
                transform.position += direction.normalized * speed * Time.deltaTime;
            }

            

            
        }
        
    }

    public void GoingBack()
    {
        if (health.isAlive)
        {
            
            
            if (!isGoingBackward)
            {
                
                direction = new Vector3(-direction.x, direction.y, direction.z);

                
                transform.Rotate(0, 180, 0);

                
                isGoingForward = false;
                isGoingBackward = true;
                speed = 3;

                Debug.Log("Soldier is going back to the trench.");
            }
        }
    }
}