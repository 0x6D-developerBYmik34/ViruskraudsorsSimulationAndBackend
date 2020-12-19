using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGenerator : MonoBehaviour
{
    public int birthRate;
    public AllPlaces allPlaces;
    public List<Human> allHumans;

    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject humanPrefab;

    public void giveBirthHuman() {

        Human h = Instantiate(humanPrefab, new Vector2(), Quaternion.identity).GetComponent<Human>();

        allHumans.Add(h);

        AllPlaces.passHuman(h);
    
    }

    public void infectHuman(int count) { 
    
    
    }

    public void killHuman(Human h)
    {


    }
}
