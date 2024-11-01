using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchUIPoint : MonoBehaviour
{
    public GameObject uiPoint;
    public Outer outer;
    public Backer backer;

    public void ReleastAllSoldiers()
    {
        outer.MarchForwardFromTheTrench();
    }

    public void ComeBackAllReleastedSoldiers()
    {
        backer.GoingBackToTheTrench();
    }

    // Start is called before the first frame update
    void Start()
    {
        outer = GetComponentInChildren<Outer>();
        backer = GetComponentInChildren<Backer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
