using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    public float velocity;
    public float maxVelocity;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(Random.Range(-velocity, velocity), Random.Range(-velocity, velocity));
        simMinute = SimulationDate.iam.getAllMinutes();
        demand.initDemand();
        foreach (GameObject go in standartDemands) {

            demandControllers.Add(go.GetComponent<IDemandController>());        
        
        }
        
    }

    int simMinute;

    public int countDemands;

    void Update()
    {
        countDemands = demandControllers.Count;
        if (rigidbody.velocity.magnitude > maxVelocity)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x / rigidbody.velocity.magnitude * velocity, rigidbody.velocity.y / rigidbody.velocity.magnitude * velocity);
        }
        if (simMinute == SimulationDate.iam.getAllMinutes()) return;
        simMinute = SimulationDate.iam.getAllMinutes();

        changeDemand();

        changePlace();
        
    }

    //==========================================================================================================
    public List<IDemandController> demandControllers = new List<IDemandController>();


    public GameObject[] standartDemands;

    public Place place;
    public Disease disease;

    public Vector2 home;
    public Vector2 work;

    [SerializeField]
    public Demand demand;

    void changeDemand() {

        List<IDemandController> forRemove = new List<IDemandController>();

        foreach (IDemandController dc in demandControllers)
        {
            if (!dc.getActiveStatus(this)) {

                forRemove.Add(dc);
                continue;

            }
            demand.changeDemand(dc);        
        }
        foreach (IDemandController p in forRemove) demandControllers.Remove(p);

    }

    public void changePlace() {

        if (demand.getMinimumValue() > 50) return;
        place.humans.Remove(this);      
        AllPlaces.passHuman(this);
    
    }

    //=====================================================================

    public void infectThis() {

        disease.infectHuman(this);
    
    }



}
