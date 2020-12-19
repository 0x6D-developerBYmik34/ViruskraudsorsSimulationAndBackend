
using System.Collections.Generic;
using UnityEngine;

public class AllPlaces : MonoBehaviour
{

    public static List<Place> allPlaces = new List<Place>();





    void Start()
    {

        allPlaces.AddRange(GetComponentsInChildren<Place>());

    }

    public static void passHuman(Human h) {

        Place p = getOptimalPlace(h);

        p.takeHuman(h);     
    
    }

    static Place getOptimalPlace(Human h) {

        DemandType minDT = h.demand.getMinimalDemandType();

        Place maxPlace = null;

        foreach (Place p in allPlaces)
        {
            if (maxPlace == null) { maxPlace = p; continue; }

            switch (minDT)
            {
                case DemandType.work: if (maxPlace.deltaWork < p.deltaWork*p.getPercentageFreeArea()) { maxPlace = p; } break;
                case DemandType.home: if (maxPlace.deltaHome < p.deltaHome * p.getPercentageFreeArea()) { maxPlace = p; } break;
                case DemandType.rest: if (maxPlace.deltaRest < p.deltaRest * p.getPercentageFreeArea()) { maxPlace = p; } break;
                case DemandType.medicine: if (maxPlace.deltaMedicine < p.deltaMedicine * p.getPercentageFreeArea()) { maxPlace = p; } break;
            }
        }

        return maxPlace;
    }


}
