using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Emploment : MonoBehaviour
{
    public Base_Factory CurrentWork;
    public int Salary;
    public JobsOS CurrentJob;

    private float StartingHours = 9;
    private float EndingHours = 17;

    private Wallet _wallet;
    private DayCycle _dayCycle;

    [HideInInspector]
    public UnityEvent EndWorkDay = new UnityEvent();

    void Start()
    {
        _wallet = GetComponent<Wallet>();
        _dayCycle = MainManger.instance.DayCycle;
    }

    public void GettingPaid()
    {
        _wallet.AddMoney(Salary);
    }

    public int HasJob()
    {
        if(CurrentWork == null && CurrentJob == null)
            return 1;

        return 0;
    }

    public int InWorkHours()
    {

        if (_dayCycle.Hours >= StartingHours && _dayCycle.Hours <= EndingHours)
        {
            EndWorkDay.Invoke();
            return 1;
        }
           

        return 0;
    }
}
