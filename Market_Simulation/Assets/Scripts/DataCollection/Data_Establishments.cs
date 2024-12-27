using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Establishments : MonoBehaviour
{
    private int TotalEstablishmentCount;
    private int FoodFactoriesCount = 0;
    private int LuxuryFactoriesCount = 0;
    private int FoodStoreCount = 0;
    private int LuxuryStoreCount = 0;

    private float TotalWealthEstablishments = 0;
    private float AverageWealthEstablishments = 0;

    [Header("Total and Average Wealth for all Establishments")]
    public List<float> TotalWealthsEstablishments = new List<float>();
    public List<float> AveragesWealthsEstablishments = new List<float>();

    private float TotalWealthFoodFactories = 0;
    private float AverageWealthFoodFactories = 0;

    [Header("Total and Average Wealth for Food Factories")]
    public List<float> TotalWealthsFoodFactories = new List<float>();
    public List<float> AveragesWealthsFoodFactories = new List<float>();
    
    private float TotalWealthLuxuryFactories = 0;
    private float AverageWealthLuxuryFactories = 0;

    [Header("Total and Average Wealth for Luxury Factories")]
    public List<float> TotalWealthsLuxuryFactories = new List<float>();
    public List<float> AveragesWealthsLuxuryFactories = new List<float>();

    private float TotalWealthFoodStores = 0;
    private float AverageWealthFoodStores = 0;

    [Header("Total and Average Wealth for Food Stores")]
    public List<float> TotalWealthsFoodStores = new List<float>();
    public List<float> AveragesWealthsFoodStores = new List<float>();

    private float TotalWealthLuxuryStores = 0;
    private float AverageWealthLuxuryStores = 0;

    [Header("Total and Average Wealth for Luxury Stores")]
    public List<float> TotalWealthsLuxuryStores = new List<float>();
    public List<float> AveragesWealthsLuxuryStores = new List<float>();

    void Start()
    {
        MainManger.instance.DayCycle.DayPassed.AddListener(CalculateAllWealth);
    }

    void CalculateAllWealth()
    {
        TotalEstablishmentCount = 0;
        TotalWealthEstablishments = 0;
        CalculateFoodFactoriesWealth();
        CalculateLuxuryFactoriesWealth();
        CalculateFoodStoresWealth();
        CalculateLuxuryStoresWealth();
        CalculateEstablishMentsWealth();
    }

    void CalculateFoodFactoriesWealth()
    {
        TotalWealthFoodFactories = 0;
        int foodFactoryCount = 0;

        foreach (Food_Factory foodFactory in MainManger.instance.EstablishmentHolder.FactoryFoodEstablishments)
        {
            TotalWealthFoodFactories += foodFactory.Money;
            foodFactoryCount++;
            TotalEstablishmentCount++;
            TotalWealthEstablishments += foodFactory.Money;
        }

        AverageWealthFoodFactories = foodFactoryCount > 0 ? TotalWealthFoodFactories / foodFactoryCount : 0;

        AveragesWealthsFoodFactories.Add(AverageWealthFoodFactories);
        TotalWealthsFoodFactories.Add(TotalWealthFoodFactories);
    }

    void CalculateLuxuryFactoriesWealth()
    {
        TotalWealthLuxuryFactories = 0;
        int luxuryFactoryCount = 0;

        foreach (Luxury_Factory luxuryFactory in MainManger.instance.EstablishmentHolder.FactoryLuxuryEstablishments)
        {
            TotalWealthLuxuryFactories += luxuryFactory.Money;
            luxuryFactoryCount++;
            TotalEstablishmentCount++;
            TotalWealthEstablishments += luxuryFactory.Money;
        }

        AverageWealthLuxuryFactories = luxuryFactoryCount > 0 ? TotalWealthLuxuryFactories / luxuryFactoryCount : 0;

        AveragesWealthsLuxuryFactories.Add(AverageWealthLuxuryFactories);
        TotalWealthsLuxuryFactories.Add(TotalWealthLuxuryFactories);
    }

    void CalculateFoodStoresWealth()
    {
        TotalWealthFoodStores = 0;
        int foodStoreCount = 0;

        foreach (Store_Food foodStore in MainManger.instance.EstablishmentHolder.StoreFoodEstablishments)
        {
            TotalWealthFoodStores += foodStore.Money;
            foodStoreCount++;
            TotalEstablishmentCount++;
            TotalWealthEstablishments += foodStore.Money;
        }

        AverageWealthFoodStores = foodStoreCount > 0 ? TotalWealthFoodStores / foodStoreCount : 0;

        AveragesWealthsFoodStores.Add(AverageWealthFoodStores);
        TotalWealthsFoodStores.Add(TotalWealthFoodStores);
    }

    void CalculateLuxuryStoresWealth()
    {
        TotalWealthLuxuryStores = 0;
        int luxuryStoreCount = 0;

        foreach (Store_Luxury luxuryStore in MainManger.instance.EstablishmentHolder.StoreLuxuryEstablishments)
        {
            TotalWealthLuxuryStores += luxuryStore.Money;
            luxuryStoreCount++;
            TotalEstablishmentCount++;
            TotalWealthEstablishments += luxuryStore.Money;


        }

        AverageWealthLuxuryStores = luxuryStoreCount > 0 ? TotalWealthLuxuryStores / luxuryStoreCount : 0;

        AveragesWealthsLuxuryStores.Add(AverageWealthLuxuryStores);
        TotalWealthsLuxuryStores.Add(TotalWealthLuxuryStores);
    }

    void CalculateEstablishMentsWealth()
    {
        AverageWealthEstablishments = TotalWealthEstablishments / TotalEstablishmentCount;
        TotalWealthsEstablishments.Add(TotalWealthEstablishments);
        AveragesWealthsEstablishments.Add(AverageWealthEstablishments);
    }

}
