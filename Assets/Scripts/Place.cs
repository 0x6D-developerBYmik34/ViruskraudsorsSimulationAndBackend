using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour, IDemandController
{

    public List<Human> humans = new List<Human>();

    public float area;

    void Start()
    {
        area = transform.localScale.x * transform.localScale.y;
        
    }

    void Update()
    {
        
    }

    public float maxDensity;
    public float getPercentageFreeArea() {

        return 1f - (humans.Count/area)/maxDensity;   
    
    }

    public void takeHuman(Human h) {

        float x = Random.RandomRange(transform.position.x - 4f*transform.localScale.x / 2f, transform.position.x + 4f*transform.localScale.x / 2f);
        float y = Random.RandomRange(transform.position.y - 4f*transform.localScale.y / 2f, transform.position.y + 4f*transform.localScale.y / 2f);


        if (h.place == null)
        {
            humans.Add(h);
            h.demandControllers.Add(this);

            h.place = this;
            h.transform.position = new Vector3(x,y,0);
        }
        else {

            if (h.place != this)
            {
                humans.Add(h);
                h.demandControllers.Add(this);

                h.transform.position = new Vector3(x, y, 0);
                h.place = this;               
            }            

        }
    
    }

    public bool getActiveStatus(Human h)
    {
        return humans.Contains(h);
    }

    public float _deltaWork;
    public float _deltaHome;
    public float _deltaRest;
    public float _deltaMedicine;


    public float deltaWork {        get => Random.value*_deltaWork; }
    public float deltaHome {        get => Random.value * _deltaHome; }
    public float deltaRest {        get => Random.value * _deltaRest; }
    public float deltaMedicine {    get => Random.value * _deltaMedicine; }


}
