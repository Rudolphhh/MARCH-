using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    
    public MonoBehaviour ShooterScript;

    [SerializeField]
    public int HP;
    public bool isDead = false;
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        

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


        
        

    }
}
