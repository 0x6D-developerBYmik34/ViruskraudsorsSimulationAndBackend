
using UnityEngine;

public class Disease : MonoBehaviour, IDemandController
{

    public float probabilityPass;

    public int incubationTimeDay;
    public int activeTimeDay;
    public int immuneTimeDay;

    SpriteRenderer spriteR;


    // Start is called before the first frame update
    void Start()
    {
       

    }

    int oldDay;
    void Update()
    {

        if (!activeStatus) return;

        if (oldDay == SimulationDate.iam._day) return;

        oldDay = SimulationDate.iam._day;

    }

    //==================================================================================

    float _deltaWork;
    float _deltaHome;
    float _deltaRest;
    float _deltaMedicine;

    Human human;

    public float deltaWork { get => Random.value * _deltaWork; }
    public float deltaHome { get => Random.value * _deltaHome; }
    public float deltaRest { get => Random.value * _deltaRest; }
    public float deltaMedicine { get => Random.value * _deltaMedicine; }

    bool activeStatus = false;
    public bool getActiveStatus(Human h)
    {
        return activeStatus;
    }

    int _incubationTimeDay;
    int _activeTimeDay;
    int _immuneTimeDay;

    public void infectHuman(Human h) {

        //if (Random.value * 100f > probabilityPass) return;

        human = h;
        spriteR = h.GetComponentInChildren<SpriteRenderer>();

        _incubationTimeDay = incubationTimeDay;
        _activeTimeDay = activeTimeDay;
        _immuneTimeDay = immuneTimeDay;
        activeStatus = true;
        oldDay = SimulationDate.iam._day;
    
    }

    public void progressDisease() {

        if (_incubationTimeDay > 0)
        {

            _deltaWork = 0;
            _deltaHome = -0.1f;
            _deltaRest = 0.1f;
            _deltaMedicine = -0.1f;

            _incubationTimeDay--;

            spriteR.color = Color.yellow;

        }
        else
        if (_activeTimeDay > 0)
        {
            _deltaWork = 2f;
            _deltaHome = -2f;
            _deltaRest = 2f;
            _deltaMedicine = -1f;

            _activeTimeDay--;

            spriteR.color = Color.red;

        }
        else
        if (_immuneTimeDay > 0)
        {
            _deltaWork = 0f;
            _deltaHome = 0f;
            _deltaRest = 0f;
            _deltaMedicine = 0f;

            _immuneTimeDay--;

            spriteR.color = Color.green;
        }
        else {

            activeStatus = false;      
        
        }

    }


}
