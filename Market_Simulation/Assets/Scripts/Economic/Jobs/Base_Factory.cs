using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base_Factory : Base_Establishment
{
    [Space(20)]
    public AvailableJobs Jobs;
    [SerializeField] protected List<Emploment> _employList = new List<Emploment>();

    [SerializeField] protected int _BaseSalary = 2000;

    [SerializeField] protected int _Income;
    [SerializeField] protected int _Outcome;

    [SerializeField] private int ProfitAmountTillNewHire = 500;

    protected virtual void Start()
    {
        MainManger.instance.DayCycle.MonthPassed.AddListener(PayEmploys);
    }


    public void PayEmploys()
    {
        foreach (Emploment employ in _employList)
        {
            employ.GettingPaid();
            Money -= employ.Salary;
            _Outcome += employ.Salary;
        }
    }

    public void CheckForProfit()
    {
        int profit = _Income - _Outcome;

        if (profit > 0)
        {
            Jobs.AvailableAmount--;

            if (Jobs.AvailableAmount < _employList.Count)
            {
                FireEmploy();
            }
        }

        if (profit < ProfitAmountTillNewHire)
        {
            Jobs.AvailableAmount++;
        }
    }


    public void HireEmploy(Emploment employ)
    {
        employ.Salary = _BaseSalary;
        employ.CurrentWork = this;
        employ.CurrentJob = Jobs.job;
        _employList.Add(employ);
        Jobs.AvailableAmount--;
    }
    public void FireEmploy()
    {
        _employList.Remove(_employList[0]);
        _employList[0].Salary = 0;
        _employList[0].CurrentWork = null;
    }
}
