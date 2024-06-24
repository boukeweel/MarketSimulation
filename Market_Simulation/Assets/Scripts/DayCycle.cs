using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    [SerializeField] private int _hours = 0;
    [SerializeField] private int _days = 0;
    [SerializeField] private int _months = 0;
    [SerializeField] private int _years = 0;

    private const int HoursInDay = 24;

    public float SecForDay = 600;
    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        float realTimeHours = SecForDay / HoursInDay;

        while (true)
        {
            for (int i = 0; i < HoursInDay; i++)
            {
                yield return new WaitForSeconds(realTimeHours);
                AddHour();
            }
            AddDay();
        }
    }

    void AddHour()
    {
        _hours++;
        if (_hours >= 24)
        {
            _hours = 0;
        }
    }

    void AddDay()
    {
        _days++;

        if (_days > 30 )
        {
            _days = 1;
            _months++;
        }

        if (_months > 12)
        {
            _months = 1;
            _years++;
        }
    }
}
