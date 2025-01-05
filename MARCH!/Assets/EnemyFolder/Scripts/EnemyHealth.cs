using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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


    public TMP_Text killedEnemiesText;

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

        gameObject.tag = "killedEnemySoldier";


        if (ShooterScript != null)
        {
            ShooterScript.enabled = false;
        }


        if (gun != null)
        {
            Destroy(gun);
        }
        Destroy(gameObject, 6f);
        
    }

    
}
