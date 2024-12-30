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

    [Header("Salary numbers")]
    [SerializeField] protected int _BaseSalary = 2100;
    [SerializeField] private int _LowestSalary = 2100;
    [SerializeField] private int _highestSalary = 3000;

    [Header("Income and Outcome of jobs")]
    [SerializeField] public float _Income;
    [SerializeField] public float _Outcome;

    [Header("Adding jobs")]
    [SerializeField] private int _profitAmountTillNewHire = 500;
    [SerializeField] private int _profitAmountTillSalaryUp = 1000;
    [SerializeField] private int _MaxAmountOfJobs = 10;
    [SerializeField] private bool _allowedToHirePeople = true;

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

        if (Money < 0 && TypeEstablishment != TypeEstablishment.Govermant)
        {
            float needed = -Money;
            Debug.LogWarning(needed +  " factory: " +gameObject.name);
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
            _BaseSalary = _LowestSalary;
            if (Jobs.AvailableAmount < _employList.Count)
            {
                FireEmploy();
            }
        }

        if (profit > _profitAmountTillNewHire && _allowedToHirePeople && _employList.Count < _MaxAmountOfJobs)
        {
            Jobs.AvailableAmount++;
        }
        else if(profit > _profitAmountTillSalaryUp && _BaseSalary < _highestSalary)
        {
            _BaseSalary += 100;
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
