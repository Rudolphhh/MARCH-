using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrenchLocker : MonoBehaviour
{
    [SerializeField]
    public bool isLocked = false;


    public Image buttonSourceImage;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(isLocked)
        {
            buttonSourceImage.sprite = lockedSprite;
        }
        else
        {
            buttonSourceImage.sprite = unlockedSprite;
        }

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
