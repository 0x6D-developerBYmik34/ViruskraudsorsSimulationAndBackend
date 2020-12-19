using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayDemand : MonoBehaviour, IDemandController
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    //=======================================================

    public AnimationCurve _deltaWork;
    public AnimationCurve _deltaHome;
    public AnimationCurve _deltaRest;
    public AnimationCurve _deltaMedicine;

    public float deltaWork { get => Random.value * _deltaWork.Evaluate(SimulationDate.iam._hour); }
    public float deltaHome { get => Random.value * _deltaHome.Evaluate(SimulationDate.iam._hour); }
    public float deltaRest { get => Random.value * _deltaRest.Evaluate(SimulationDate.iam._hour); }
    public float deltaMedicine { get => Random.value * _deltaMedicine.Evaluate(SimulationDate.iam._hour); }

    public bool getActiveStatus(Human h)
    {
        return true;
    }
}
