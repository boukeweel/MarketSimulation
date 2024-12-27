using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public float MoneyForLuxuryItem;

    private float money = 2000;

    public float Money
    {
        get => money;
        set => money = Mathf.Round(value * 100) / 100; // Ensures only two decimal places
    }

    public bool SpendMoney(float amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            UpdateLuxuryBudget();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateLuxuryBudget()
    {
        MoneyForLuxuryItem = Money / 100;
    }

    public void AddMoney(int amount)
    {
        if (amount <= 0)
        {
            return;
        }
        Money += amount;
        UpdateLuxuryBudget();
    }
}
