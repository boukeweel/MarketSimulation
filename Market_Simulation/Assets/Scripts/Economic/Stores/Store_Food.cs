using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class Store_Food : Base_Establishment
{
    [Space(20)]
    public List<FoodData> FoodTypes = new List<FoodData>();

    [SerializeField] private int MaxAmountOfOneFoodType = 40;

    void Awake()
    {
        ProductType = ProductType.Food;
        TypeEstablishment = TypeEstablishment.Store;
    }

    void Start()
    {
        MainManger.instance.EstablishmentHolder.StoreFoodEstablishments.Add(this);
    }

    public int FindFoodToBuyPerson(float budget, int preferredQuality)
    {
        float tax = Goverment.instance.FoodTax;
        bool preferredQualityFound = false;
        //step 1 check for food with perfferedQuality
        for (int i = 0; i < FoodTypes.Count; i++)
        {
            if (FoodTypes[i].AvailableAmount > 0 && FoodTypes[i].FoodType.Quality == preferredQuality)
            {
                if (FoodTypes[i].FoodType.ShopSellPrice + (FoodTypes[i].FoodType.ShopSellPrice * tax) <= budget)
                {
                    return i;
                }
                else
                {
                    preferredQualityFound = true;
                }
            }
        }

        // Step 2: If no preferred quality food was found, and they were not too expensive, check for higher quality foods
        if (!preferredQualityFound)
        {
            for (int i = 0; i < FoodTypes.Count; i++)
            {
                if (FoodTypes[i].AvailableAmount > 0 && FoodTypes[i].FoodType.Quality > preferredQuality && FoodTypes[i].FoodType.ShopSellPrice + (FoodTypes[i].FoodType.ShopSellPrice * tax) <= budget)
                {
                    return i;
                }
            }
        }
        
        // Step 3: If no preferred or higher quality food found, check lower quality foods
        return CheckLowerQualityFoods(budget, preferredQuality);
    }
    // Helper function to check for lower quality foods
    private int CheckLowerQualityFoods(float budget,int preferredQuality)
    {
        float tax = Goverment.instance.FoodTax;
        for (int i = 0; i < FoodTypes.Count; i++)
        {
            if (FoodTypes[i].AvailableAmount > 0 && FoodTypes[i].FoodType.Quality < preferredQuality && FoodTypes[i].FoodType.ShopSellPrice + (FoodTypes[i].FoodType.ShopSellPrice * tax) <= budget)
            {
                return i;
            }
        }

        // If no food is found in any category, return -1 to indicate no available food
        return -1;
    }
    public FoodTypeSO BuyFoodPerson(int foodIndex)
    {
        if (foodIndex >= 0 && foodIndex < FoodTypes.Count)
        {
            if (FoodTypes[foodIndex].AvailableAmount > 0)
            {
                FoodTypes[foodIndex].AvailableAmount--;
                Money += FoodTypes[foodIndex].FoodType.ShopSellPrice;
                return FoodTypes[foodIndex].FoodType;
            }
        }
        return null;
    }

    public bool WantedToBuyFood(FoodTypeSO type)
    {
        if (type.ShopBuyPrice > Money) return false;

        foreach (FoodData foodData in FoodTypes)
        {
            if (foodData.FoodType.UniqueID == type.UniqueID)
            {
                if (foodData.AvailableAmount >= MaxAmountOfOneFoodType) return false;
            }
        }
        return true;
    }
    public void BuyOneProduct(FoodTypeSO foodType)
    {
        float tax = 0;
        for (int i = 0; i < FoodTypes.Count; i++)
        {
            if (FoodTypes[i].FoodType.UniqueID == foodType.UniqueID)
            {
                FoodTypes[i].AvailableAmount++;
                tax = FoodTypes[i].ProductType.ShopBuyPrice * Goverment.instance.FactoryTax;
                Goverment.instance.GetMoney(tax);
                Money -= FoodTypes[i].ProductType.ShopBuyPrice + tax;
                return;
            }
        }

        FoodData newFoodData = new FoodData { };
        newFoodData.FoodType = foodType;
        newFoodData.AvailableAmount++;

        tax = newFoodData.ProductType.ShopBuyPrice * Goverment.instance.FactoryTax;
        Goverment.instance.GetMoney(tax);
        Money -= newFoodData.ProductType.ShopBuyPrice + tax;
        FoodTypes.Add(newFoodData);
    }
}
