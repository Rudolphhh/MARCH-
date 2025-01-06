using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Vector3 direction;
    private Animator mAnimator;
    public GameObject gun;
    public MonoBehaviour ShooterScript;

    [SerializeField]
    public int HP;
    public bool isDead = false;
    public bool isAlive;

    
    public KillCounter killCounter;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        mAnimator = GetComponent<Animator>();

        if (killCounter == null)
        {
            killCounter = FindObjectOfType<KillCounter>();
        }

        if (killCounter == null)
        {
            Debug.LogError("No KillCounter found in the scene. Please add one.");
        }
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

        gameObject.tag = "killedEnemySoldier";

        if (ShooterScript != null)
        {
            ShooterScript.enabled = false;
        }

        if (gun != null)
        {
            Destroy(gun);
        }

        
        if (killCounter != null)
        {
            killCounter.AddKill();
        }

        Destroy(gameObject, 6f);
    }
}
