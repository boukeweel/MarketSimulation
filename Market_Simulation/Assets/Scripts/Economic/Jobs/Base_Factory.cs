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

    protected virtual void Start()
    {
        MainManger.instance.DayCycle.MonthPassed.AddListener(PayEmploys);
    }


    public void PayEmploys()
    {
        foreach (Emploment employ in _employList)
        {
            employ.GettingPaid();
            _money -= employ.Salary;
        }

        if (_money < 0)
            FireEmploy();
    }
    public void HireEmploy(Emploment employ)
    {
        employ.Salary = _BaseSalary;
        employ.CurrentWork = this;
        AddNewEmploy(employ);
    }
    public void FireEmploy()
    {
        RemoveEmploy(_employList[0]);
        _employList[0].Salary = 0;
        _employList[0].CurrentWork = null;
    }
    private void AddNewEmploy(Emploment employ)
    {
        _employList.Add(employ);
        Jobs.AvailableAmount--;
    }
    private void RemoveEmploy(Emploment employ)
    {
        _employList.Remove(employ);
        Jobs.AvailableAmount++;
    }
}
