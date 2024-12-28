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
    [HideInInspector] public UnityEvent HourPassed = new UnityEvent();
    [HideInInspector] public UnityEvent DayPassed = new UnityEvent();
    [HideInInspector] public UnityEvent WeekPassed = new UnityEvent();
    [HideInInspector] public UnityEvent MonthPassed = new UnityEvent();
    [HideInInspector] public UnityEvent YearPassed = new UnityEvent();

    private const int HoursInDay = 24;

    //minutes in real day is 1440 / 12 = 120
    [Header("default is 120")]
    [SerializeField] private float _secForDay = 120;
    private void Start()
    {
        StartCoroutine(TimerCoroutine());
        YearPassed.AddListener(OneYear);
    }

    private void OneYear()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
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
        HourPassed.Invoke();
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

        if (Months == 12)
        {
            Months = 1;
            Years++;
            YearPassed.Invoke();
        }
    }
}
