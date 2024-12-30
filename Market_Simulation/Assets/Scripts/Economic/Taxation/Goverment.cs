using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goverment : MonoBehaviour
{
    public static Goverment instance;

    public float FoodTax { get; private set; } = .1f;
    public float LuxuryTax { get; private set; } = .2f;
    public float FactoryTax { get; private set; } = .175f;

    [HideInInspector] public List<float> Moneys = new List<float>();

    private Base_Factory _govermentWork;
    
    void Awake()
    {
        instance = this;
        _govermentWork = GetComponent<Base_Factory>();
        _govermentWork.TypeEstablishment = TypeEstablishment.Govermant;
        MainManger.instance.EstablishmentHolder.Goverment = _govermentWork;
    }

    void Start()
    {
        MainManger.instance.DayCycle.DayPassed.AddListener(AddTolist);
    }
    private void AddTolist()
    {
        Moneys.Add(_govermentWork.Money);
    }

    public void GetMoney(float Amount)
    {
        _govermentWork.Money += Amount;
        _govermentWork._Income += Amount;
    }

    public bool AllowedToHelp(float NeedCash)
    {
        if(NeedCash > _govermentWork.Money)
            return false;

        return true;
    }

    public float GiveMoneySupport(float needed)
    {
        _govermentWork.Money -= needed;
        _govermentWork._Outcome += needed;
        return needed;
    }
}
