using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    private Health health;
    private Rigidbody rb;
    private Animator mAnimator;

    public bool isInTrench = false;
    public bool isGoingForward = true;
    public bool isGoingBackward = false;

    [SerializeField]
    public int speed;

    public Vector3 direction = new Vector3(1, 0, 0);

    private bool isShooting = false;

    
    [SerializeField] private Shooter shooter;

    
    public void Start()
    {
        
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();
    }

    
    public void Update()
    {
        if (health.isDead == false)
        {
            if (mAnimator != null)
            {
                if (isGoingForward == false && isGoingBackward == false)
                {
                    mAnimator.SetBool("isWalkingAnim", false);
                }
                else if (isGoingForward == true)
                {
                    mAnimator.SetBool("isWalkingAnim", true);
                }
                else if (isInTrench == true)
                {
                    mAnimator.SetBool("isWalkingAnim", false);
                }
            }
        }
        else if (health.isDead == true && isGoingForward == true)
        {
            isGoingForward = false;
            mAnimator.SetBool("isDeadWhileWalking", true);

            mAnimator.SetBool("isWalkingAnim", false);
        }
        else if (health.isDead == true && isGoingForward == false)
        {
            mAnimator.SetBool("isDeadWhileIdle", true);
        }

        
        if (!isShooting && health.isAlive && !isInTrench)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }

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
            }
        }
    }

    
    public void StartShooting()
    {
        isShooting = true;
        mAnimator.SetBool("isWalkingAnim", false);
    }

    
    public void StopShooting()
    {
        isShooting = false;
        mAnimator.SetBool("isWalkingAnim", true);
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

                Debug.Log("Soldier is going back to the trench.");
            }
        }
    }
}