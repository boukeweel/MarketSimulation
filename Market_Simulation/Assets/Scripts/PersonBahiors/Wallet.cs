using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField]
    private int savings = 2000;

    public int MoneyForLuxuryItem;

    public int Savings
    {
        get => savings;
        private set => savings = value;
    }

    public bool SpendMoney(int amount)
    {
        if (savings >= amount)
        {
            savings -= amount;
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
        MoneyForLuxuryItem = savings / 100;
    }

    public void AddMoney(int amount)
    {
        if (amount <= 0)
        {
            return;
        }
        savings += amount;
        UpdateLuxuryBudget();
    }
}
