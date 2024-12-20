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

    public int FindFoodToBuyPerson(int budget, int preferredQuality)
    {
        bool preferredQualityFound = false;
        //step 1 check for food with perfferedQuality
        for (int i = 0; i < FoodTypes.Count; i++)
        {
            if (FoodTypes[i].AvailableAmount > 0 && FoodTypes[i].FoodType.Quality == preferredQuality)
            {
                if (FoodTypes[i].FoodType.ShopSellPrice <= budget)
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
                if (FoodTypes[i].AvailableAmount > 0 && FoodTypes[i].FoodType.Quality > preferredQuality && FoodTypes[i].FoodType.ShopSellPrice <= budget)
                {
                    return i;
                }
            }
        }
        
        // Step 3: If no preferred or higher quality food found, check lower quality foods
        return CheckLowerQualityFoods(budget, preferredQuality);
    }
    // Helper function to check for lower quality foods
    private int CheckLowerQualityFoods(int budget,int preferredQuality)
    {
        for (int i = 0; i < FoodTypes.Count; i++)
        {
            if (FoodTypes[i].AvailableAmount > 0 && FoodTypes[i].FoodType.Quality < preferredQuality && FoodTypes[i].FoodType.ShopSellPrice <= budget)
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
            FoodData foodData = FoodTypes[foodIndex];

            if (foodData.AvailableAmount > 0)
            {
                foodData.AvailableAmount--;
                FoodTypes[foodIndex] = foodData;
                Money += foodData.FoodType.ShopSellPrice;
                return foodData.FoodType;
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
        for (int i = 0; i < FoodTypes.Count; i++)
        {
            if (FoodTypes[i].FoodType.UniqueID == foodType.UniqueID)
            {
                FoodData foodData = FoodTypes[i];
                foodData.AvailableAmount++;
                FoodTypes[i] = foodData;
                Money -= foodData.ProductType.ShopBuyPrice;
                return;
            }
        }

        FoodData newFoodData = new FoodData { };
        newFoodData.FoodType = foodType;
        newFoodData.AvailableAmount++;
        Money -= newFoodData.ProductType.ShopBuyPrice;
        FoodTypes.Add(newFoodData);
    }
}
