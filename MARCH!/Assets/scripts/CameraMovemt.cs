using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovemt : MonoBehaviour
{
    public float moveSpeed = 30f;   
    public float minX = -30f;       
    public float maxX = 30f;        

    void Update()
    {
        
        float inputX = Input.GetAxis("Horizontal");

        
        float newX = transform.position.x + inputX * moveSpeed * Time.deltaTime;

        
        newX = Mathf.Clamp(newX, minX, maxX);

        
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
