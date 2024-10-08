using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{

    public bool isInTrench = false;
    public bool isGoingForward = true;
    public bool isGoingBackward = false;
    [SerializeField]
    private int speed;

    public Vector3 direction = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
