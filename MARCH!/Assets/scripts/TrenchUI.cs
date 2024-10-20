using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchUI : MonoBehaviour
{
    Camera cam;
    public Transform trenchUIPosition;
    public RectTransform buttonRect;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        var screenPos = cam.WorldToScreenPoint(trenchUIPosition.position);
        buttonRect.position = screenPos;
    }
}