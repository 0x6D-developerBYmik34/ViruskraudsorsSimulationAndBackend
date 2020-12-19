using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holydays : MonoBehaviour, IDemandController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //==================================================================================

    public Demand monday;
    public Demand tuesday;
    public Demand wednesday;
    public Demand thursday;
    public Demand friday;
    public Demand saturday;
    public Demand sunday;

    public float deltaWork      { get => Random.value * getDeltaWork(); }
    public float deltaHome      { get => Random.value * getDeltaHome(); }
    public float deltaRest      { get => Random.value * getDeltaRest(); }
    public float deltaMedicine  { get => Random.value * getDeltaMedicine(); }

    public bool getActiveStatus(Human h)
    {
        return true;
    }

    float getDeltaWork() {

        switch (SimulationDate.iam._week) {

            case Week.Monday:       return monday.work;         break;
            case Week.Tuesday:      return tuesday.work;        break;
            case Week.Wednesday:    return wednesday.work;      break;
            case Week.Thursday:    return thursday.work;       break;
            case Week.Friday:       return friday.work;         break;
            case Week.Saturday:     return saturday.work;       break;
            case Week.Sunday:       return sunday.work;         break;

        }

        return 0;
    
    }

    float getDeltaHome()
    {

        switch (SimulationDate.iam._week)
        {

            case Week.Monday:       return monday.home;     break;
            case Week.Tuesday:      return tuesday.home;    break;
            case Week.Wednesday:    return wednesday.home;  break;
            case Week.Thursday:    return thursday.home;   break;
            case Week.Friday:       return friday.home;     break;
            case Week.Saturday:     return saturday.home;   break;
            case Week.Sunday:       return sunday.home;     break;

        }

        return 0;

    }

    float getDeltaRest()
    {

        switch (SimulationDate.iam._week)
        {

            case Week.Monday:       return monday.rest;     break;
            case Week.Tuesday:      return tuesday.rest;    break;
            case Week.Wednesday:    return wednesday.rest;  break;
            case Week.Thursday:    return thursday.rest;   break;
            case Week.Friday:       return friday.rest;     break;
            case Week.Saturday:     return saturday.rest;   break;
            case Week.Sunday:       return sunday.rest;     break;

        }

        return 0;

    }

    float getDeltaMedicine()
    {

        switch (SimulationDate.iam._week)
        {

            case Week.Monday:       return monday.medicine;         break;
            case Week.Tuesday:      return tuesday.medicine;        break;
            case Week.Wednesday:    return wednesday.medicine;      break;
            case Week.Thursday:    return thursday.medicine;       break;
            case Week.Friday:       return friday.medicine;         break;
            case Week.Saturday:     return saturday.medicine;       break;
            case Week.Sunday:       return sunday.medicine;         break;

        }

        return 0;
    }
}
