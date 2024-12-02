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

    private bool isShooting = false; // Track if soldier is shooting

    // Reference to the Shooter script
    [SerializeField] private Shooter shooter;

    // Start is called before the first frame update
    public void Start()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
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

        // Stop movement when shooting
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

    // Call this method to start shooting and stop moving
    public void StartShooting()
    {
        isShooting = true;
        mAnimator.SetBool("isWalkingAnim", false); // Stop the walking animation
    }

    // Call this method to stop shooting and resume moving
    public void StopShooting()
    {
        isShooting = false;
        mAnimator.SetBool("isWalkingAnim", true); // Resume the walking animation
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