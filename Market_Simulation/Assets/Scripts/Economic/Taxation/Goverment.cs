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

    [HideInInspector] public List<float> Moneys = new List<float>();

    
    public float Money
    {
        get => money;
        set => money = Mathf.Round(value * 100) / 100; // Ensures only two decimal places
    }


    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        MainManger.instance.DayCycle.DayPassed.AddListener(AddTolist);
    }
    private void AddTolist()
    {
        Moneys.Add(Money);
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
