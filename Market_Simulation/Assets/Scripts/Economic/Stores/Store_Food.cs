using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class Store_Food : Base_Establishment
{
    [Space(20)]
    public List<FoodData> FoodTypes;

    void Awake()
    {
        ProductType = ProductType.Food;
        TypeEstablishment = TypeEstablishment.Store;
    }

    void Start()
    {
        MainManger.instance.EstablishmentHolder.StoreFoodEstablishments.Add(this);
    }

    //for Person
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
    //for people
    public FoodTypeSO BuyFoodPerson(int foodIndex)
    {
        if (foodIndex >= 0 && foodIndex < FoodTypes.Count)
        {
            FoodData foodData = FoodTypes[foodIndex];

            if (foodData.AvailableAmount > 0)
            {
                foodData.AvailableAmount--;
                FoodTypes[foodIndex] = foodData;
                _money += foodData.FoodType.ShopSellPrice;
                return foodData.FoodType;
            }
        }
        return null;
    }



    public void AddFood(FoodTypeSO foodType, int quantityToAdd)
    {
        if (quantityToAdd > 0)
        {
            for (int i = 0; i < FoodTypes.Count; i++)
            {
                if (FoodTypes[i].FoodType.UniqueID == foodType.UniqueID) // Compare UniqueID (int)
                {
                    FoodData foodData = FoodTypes[i];
                    foodData.AvailableAmount += quantityToAdd;
                    FoodTypes[i] = foodData;
                    return;
                }
            }
        }

        // If not found, add a new FoodData entry to the list
        FoodData newFoodData = new FoodData{};
        newFoodData.FoodType = foodType;
        FoodTypes.Add(newFoodData);
    }
}
