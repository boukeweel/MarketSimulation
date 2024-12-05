using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Emploment : MonoBehaviour
{
    public Base_Factory CurrentWork;
    public int Salary;

    private Wallet _wallet;

    void Start()
    {
        _wallet = GetComponent<Wallet>();
    }

    public void GettingPaid()
    {
        _wallet.AddMoney(Salary);
    }
}
