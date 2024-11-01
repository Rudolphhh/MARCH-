using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchControlsMenu : MonoBehaviour
{
    TrenchUIPoint trench;
    RectTransform rectTransform;
    Camera cam;
    


    void Awake()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }
    public void SetTrench(TrenchUIPoint trench)
    {
        this.trench = trench;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (trench == null) return;
        rectTransform.position = cam.WorldToScreenPoint(trench.uiPoint.transform.position);
    }


    public void GoOut()
    {

        trench.ReleastAllSoldiers();

    }

    public void ComeBack()
    {
        trench.ComeBackAllReleastedSoldiers();
    }







}
