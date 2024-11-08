using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Health health;
    private Rigidbody rb;
    private Animator mAnimator;

    public bool isInTrench = false;
    public bool isGoingForward = true;
    public bool isGoingBackward = false;

    [SerializeField]
    public int speed;

    public Vector3 direction = new Vector3(-1, 0, 0); // Směr z pravé strany doleva

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
                direction = new Vector3(-direction.x, direction.y, direction.z); // Změna směru na opačný
                transform.Rotate(0, 180, 0); // Otočení modelu o 180 stupňů

                isGoingForward = false;
                isGoingBackward = true;
                

                Debug.Log("Soldier is going back to the trench.");
            }
        }
    }
}
