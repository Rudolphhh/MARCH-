using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
{

    [SerializeField]
    private NormalSoldier soldier;

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
        if (collision.gameObject.CompareTag("Soldier"))
        {
            soldier = collision.gameObject.GetComponent<NormalSoldier>();

            if (soldier != null)
            {
                HideInTheTrench();
            }
        }
    }

    public void HideInTheTrench()
    {
        soldier.isInTrench = true;
        soldier.speed = 0;
        soldier.isGoingForward = false;

        Vector3 newPosition = soldier.transform.position;
        newPosition.x += 5;
        newPosition.y += 0.6f;
        soldier.transform.position = newPosition;

        Debug.Log("dsa");
    }


    public void MarchForwardFromTheTrench()
    {
        Vector3 newPosition = soldier.transform.position;
        newPosition.x += 5;
        newPosition.y -= 0.6f;
        soldier.transform.position = newPosition;
        soldier.isInTrench = false;
        soldier.speed = 3;
        soldier.isGoingForward = true;
    }

    public void GoingBackToTheTrench()
    {
        soldier.isInTrench = false;
        soldier.speed = 3;
        soldier.isGoingForward = false;
        soldier.isGoingBackward = true;

    }
}
