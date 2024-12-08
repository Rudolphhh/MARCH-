using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyHealth ehealth;
    private Rigidbody rb;
    private Animator mAnimator;

    public bool isInTrench = false;
    public bool isGoingForward = true;
    public bool isGoingBackward = false;

    [SerializeField]
    public int speed;

    public Vector3 direction = new Vector3(-1, 0, 0); // Směr z pravé strany doleva

    private bool isShooting = false;

    // Start is called before the first frame update
    public void Start()
    {
        
        ehealth = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (ehealth.isDead == false)
        {
            if (mAnimator != null)
            {
                if (isGoingForward == false)
                {
                    mAnimator.SetBool("isWalkingAnim", false);
                }
                else if (isGoingForward == true)
                {
                    mAnimator.SetBool("isWalkingAnim", true);
                }
            }
        }
        else if (ehealth.isDead == true && isGoingForward == true)
        {
            isGoingForward = false;
            mAnimator.SetBool("isDeadWhileWalking", true);
            mAnimator.SetBool("isWalkingAnim", false);
        }
        else if (ehealth.isDead == true && isGoingForward == false)
        {
            mAnimator.SetBool("isDeadWhileIdle", true);
        }

        if (ehealth.isAlive)
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

        if (!isShooting && ehealth.isAlive && !isInTrench)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }


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
        if (ehealth.isAlive)
        {
            if (!isGoingBackward)
            {
                direction = new Vector3(-direction.x, direction.y, direction.z); // Změna směru na opačný
                transform.Rotate(0, 180, 0); // Otočení modelu o 180 stupňů

                isGoingForward = false;
                isGoingBackward = true;
                

                Debug.Log("Soldier is going back to the trench.");
            }
        }
    }
}
