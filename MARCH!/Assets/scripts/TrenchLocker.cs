using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchLocker : MonoBehaviour
{
    [SerializeField]
    public bool isLocked = false;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void LockTrench()
    {
        if(isLocked == true)
        {
            isLocked = false;
        }
        else if(isLocked == false)
        {
            isLocked=true;
        }
    }
    
}
