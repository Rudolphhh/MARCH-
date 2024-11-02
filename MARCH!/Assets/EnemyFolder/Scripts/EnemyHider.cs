using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHider : MonoBehaviour
{
    [SerializeField]
    private EnemyMovement Enemysoldier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemySoldier"))
        {
            Enemysoldier = collision.gameObject.GetComponent<EnemyMovement>();

            if (Enemysoldier != null)
            {
                HideInTheTrench();
            }
        }
    }

    public void HideInTheTrench()
    {
        Enemysoldier.isInTrench = true;
        Enemysoldier.speed = 0;
        Enemysoldier.isGoingForward = false;

        Vector3 newPosition = Enemysoldier.transform.position;
        newPosition.x -= 6;
        newPosition.y += 0.6f;
        Enemysoldier.transform.position = newPosition;


    }
}
