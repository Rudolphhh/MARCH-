using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderBack : MonoBehaviour
{
    [SerializeField]
    private NormalSoldier soldier;
    private TrenchLocker trenchlocker;

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
                HideInTheTrenchFromGoingBack();
            }
        }
    }




    public void HideInTheTrenchFromGoingBack()
    {
        
        
            soldier.isInTrench = true;
            soldier.speed = 0;
            soldier.isGoingForward = false;


            Vector3 newPosition = soldier.transform.position;
            newPosition.x -= 5;
            newPosition.y += 0.6f;
            soldier.transform.position = newPosition;


            soldier.transform.Rotate(0, 180, 0);


            soldier.direction = new Vector3(1, soldier.direction.y, soldier.direction.z);

            Debug.Log("Soldier has returned to the trench, is facing forward, and has the correct direction.");
        
        
    }
}
