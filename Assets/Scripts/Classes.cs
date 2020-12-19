
using UnityEngine;

public enum Week { 

    Monday=1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday

}

public enum DemandType {
    work,
    home,
    rest,
    medicine
}
public interface IDemandController 
{
    float deltaWork {get;}
    float deltaHome { get;}
    float deltaRest { get;}
    float deltaMedicine { get;}

    bool getActiveStatus(Human h);

}

[System.Serializable]
public struct Demand {

    public float work;
    public float home;
    public float rest;
    public float medicine;

    public void initDemand() {

        work = Random.value*100;
        home = Random.value * 100;
        rest = Random.value * 100;
        medicine = Random.value * 100;   
    
    }

    public void changeDemand(IDemandController dc) {

        work += dc.deltaWork;
        home += dc.deltaHome;
        rest += dc.deltaRest;
        medicine += dc.deltaMedicine;

        if (work < 0) { work = 0; } else if (work > 100) { work = 100f; }
        if (home < 0) { home = 0; } else if (home > 100) { home = 100f; }
        if (rest < 0) { rest = 0; } else if (rest > 100) { rest = 100f; }
        if (medicine < 0) { medicine = 0; } else if (medicine > 100) { medicine = 100f; }

    }

    public DemandType getMinimalDemandType() {

        float minimum = work;
        if (home < minimum) minimum = home;
        if (rest < minimum) minimum = rest;
        if (medicine < minimum) minimum = medicine;

        if (home == minimum) return DemandType.home;
        if (rest == minimum) return DemandType.rest;
        if (medicine == minimum) return DemandType.medicine;

        return DemandType.work;

    }

    public float getMinimumValue() 
    {
        float minimum = work;
        if (home < minimum) minimum = home;
        if (rest < minimum) minimum = rest;
        if (medicine < minimum) minimum = medicine;

        return minimum;
    }

}

