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

    [SerializeField] protected float _Income;
    [SerializeField] protected float _Outcome;

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

        if (Money < 0)
        {
            float needed = -Money;
            Debug.LogWarning(needed);
            AskLoan(needed);
        }
           

        CheckForProfit();
    }

    private void AskLoan(float MoneyNeed)
    {
        if (Goverment.instance.AllowedToHelp(MoneyNeed))
        {
            Money += Goverment.instance.GiveMoneySupport(MoneyNeed);
        }
    }

    private void CheckForProfit()
    {
        float profit = _Income - _Outcome;

        if (profit < 0)
        {
            if (Jobs.AvailableAmount < _employList.Count)
            {
                FireEmploy();
            }
        }

        if (profit > ProfitAmountTillNewHire)
        {
            Jobs.AvailableAmount++;
        }

        _Outcome = 0;
        _Income = 0;
    }


    public void HireEmploy(Emploment employ)
    {
        employ.Salary = _BaseSalary;
        employ.CurrentWork = this;
        employ.CurrentJob = Jobs.job;
        _employList.Add(employ);
        Jobs.AvailableAmount--;

        Debug.Log("Hiring New Employ");
    }
    public void FireEmploy()
    {
        Emploment firedEmployee = _employList[_employList.Count - 1];

        // Set the employee's salary and work to null
        firedEmployee.Salary = 0;
        firedEmployee.CurrentWork = null;
        firedEmployee.CurrentJob = null;

        // Remove the last employee from the list
        _employList.RemoveAt(_employList.Count - 1);

        // Optionally, trim excess list capacity
        _employList.TrimExcess();

        Debug.Log("fired Employ");
    }
}
