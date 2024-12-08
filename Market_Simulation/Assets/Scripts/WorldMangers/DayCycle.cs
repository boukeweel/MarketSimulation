using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DayCycle : MonoBehaviour
{
    public int Hours = 0;
    public int Days = 0;
    public int Weeks = 0;
    public int Months = 0;
    public int Years = 0;

    [Header("Events")]
    public UnityEvent DayPassed = new UnityEvent();
    public UnityEvent WeekPassed = new UnityEvent();
    public UnityEvent MonthPassed = new UnityEvent();
    public UnityEvent YearPassed = new UnityEvent();

    private const int HoursInDay = 24;

    //minutes in real day is 1440 / 12 = 120
    private const float _secForDay = 120;
    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        float realTimeHours = _secForDay / HoursInDay;

        while (true)
        {
            for (int i = 0; i < HoursInDay; i++)
            {
                yield return new WaitForSeconds(realTimeHours);
                AddHour();
            }
        }
    }

    void AddHour()
    {
        Hours++;
        if (Hours >= 24)
        {
            AddDay();
            Hours = 0;
        }
    }

    void AddDay()
    {
        Days++;
        DayPassed.Invoke();

        if (Days == 7)
        {
            Days = 0;
            Weeks++;
            WeekPassed.Invoke();
        }

        if (Weeks == 4 )
        {
            Weeks = 0;
            Months++;
            MonthPassed.Invoke();
        }

        if (Months > 12)
        {
            Months = 1;
            Years++;
            YearPassed.Invoke();
        }
    }
}
