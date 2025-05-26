using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pohybKamery : MonoBehaviour
{
    public Transform target;        
    public float horizontalAmplitude = 1f;  
    public float verticalAmplitude = 1f;    
    public float movementSpeed = 1f;        

    private Vector3 initialOffset;

    void Start()
    {
        // Zapamatujeme si počáteční offset od cíle
        initialOffset = transform.position - target.position;
    }

    void Update()
    {
        
        float x = Mathf.Sin(Time.time * movementSpeed) * horizontalAmplitude;
        float y = Mathf.Cos(Time.time * movementSpeed) * verticalAmplitude;

        
        Vector3 offset = initialOffset + new Vector3(x, y, 0f);
        transform.position = target.position + offset;

        
    }
}
