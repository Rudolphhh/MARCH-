using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private NormalSoldier soldier;
    private Vector3 direction;

    [SerializeField]
    private int HP;
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

        //animace umreni
        if (isDead = true)
        {
            direction = new Vector3(direction.x, direction.y, direction.z);
            transform.Rotate(68.208f, -13.654f, -85.502f);
        }
        
    }
}
