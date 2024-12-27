using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goverment : MonoBehaviour
{
    public static Goverment instance;

    public float FoodTax { get; private set; } = .1f;
    public float LuxuryTax { get; private set; } = .2f;
    public float FactoryTax { get; private set; } = .2f;

    [SerializeField] private float money = 0;
    public float Money
    {
        get => money;
        set => money = Mathf.Round(value * 100) / 100; // Ensures only two decimal places
    }

    void Awake()
    {
        instance = this;
    }

    public void GetMoney(float Amount)
    {
        Money += Amount;
    }

    public bool AllowedToHelp(float NeedCash)
    {
        if(NeedCash > Money)
            return false;

        return true;
    }

    public float GiveMoneySupport(float needed)
    {
        Money -= needed;
        return needed;
    }
}
