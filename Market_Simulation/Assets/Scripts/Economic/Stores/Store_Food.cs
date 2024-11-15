using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[Serializable]
public struct FoodData
{
    public FoodTypeSO foodType;
    public int AvailableAmount;
}

public class Store_Food : MonoBehaviour
{
    public List<FoodData> FoodTypes;

    public int FindFoodToBuy(int budget, int preferredQuality)
    {
        bool preferredQualityFound = false;
        //step 1 check for food with perfferedQuality
        for (int i = 0; i < FoodTypes.Count; i++)
        {
            if (FoodTypes[i].AvailableAmount > 0 && FoodTypes[i].foodType.Quality == preferredQuality)
            {
                if (FoodTypes[i].foodType.Price <= budget)
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
                if (FoodTypes[i].AvailableAmount > 0 && FoodTypes[i].foodType.Quality > preferredQuality && FoodTypes[i].foodType.Price <= budget)
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
            if (FoodTypes[i].AvailableAmount > 0 && FoodTypes[i].foodType.Quality < preferredQuality && FoodTypes[i].foodType.Price <= budget)
            {
                return i;
            }
        }

        // If no food is found in any category, return -1 to indicate no available food
        return -1;
    }

    public FoodTypeSO BuyFood(int foodIndex)
    {
        if (foodIndex >= 0 && foodIndex < FoodTypes.Count)
        {
            FoodData foodData = FoodTypes[foodIndex];

            if (foodData.AvailableAmount > 0)
            {
                foodData.AvailableAmount--;
                FoodTypes[foodIndex] = foodData;

                return foodData.foodType;
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
                if (FoodTypes[i].foodType.UniqueID == foodType.UniqueID) // Compare UniqueID (int)
                {
                    FoodData foodData = FoodTypes[i];
                    foodData.AvailableAmount += quantityToAdd;
                    FoodTypes[i] = foodData;
                    return;
                }
            }
        }
    }
}
