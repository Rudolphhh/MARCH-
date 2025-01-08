using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private NormalSoldier soldier;
    private Vector3 direction;
    private Animator mAnimator;
    public GameObject gun;
    public GameObject gun2;
    public MonoBehaviour ShooterScript;

    [SerializeField]
    public int HP;
    public bool isDead = false;
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        mAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 && !isDead)
        {
            Killed();
        }
        



    }

    private void Killed()
    {
        isDead = true;
        isAlive = false;

        gameObject.tag = "killedSoldier";

        if (ShooterScript != null)
        {
            ShooterScript.enabled = false;
        }

        
        if (gun != null)
        {
            Destroy(gun);
        }

        if (gun2 != null)
        {
            Destroy(gun2);
        }
        Destroy(gameObject, 6f);

    }
}
