using UnityEngine;

public class SimulationDate : MonoBehaviour
{

    public int _year = 2000;
    public int _month = 1;
    public int _day = 1;
    public int _hour;
    public int _minute;
    public int _second;

    public Week _week;


    public int simulatedSecondPerSecond = 1;


    float dt = 0;

    public static SimulationDate iam;

    void Start()
    {
        iam = this;

    }


    void Update()
    {

        dt += Time.deltaTime;

        if (dt < 1.0) return;

        dt = 0;      

        changeTime();

    }

    void changeTime() {


        _second += simulatedSecondPerSecond;

        _minute += (int)(_second / 60);
        _second = _second % 60;

        _hour += (int)(_minute/ 60);
        _minute = _minute % 60;

        _day += (int)(_hour / 24);
        _hour = _hour % 24;

        _month += (int)(_day / 30);
        _day = _day % 30;

        _year += (int)(_month / 30);
        _month = _month % 30;

        int week = _day % 7 + 1;
        _week = (Week)week;

    }

    public int getAllMinutes() {

        return _minute + _hour * 60 + _day * 24 + _month * 30 + _year * 12;    
    
    }
}
