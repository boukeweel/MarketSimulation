using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<FoodData> foodItems = new List<FoodData>();

    public void AddFood(FoodTypeSO foodType)
    {
        for (int i = 0; i < foodItems.Count; i++)
        {
            if (foodItems[i].foodType.UniqueID == foodType.UniqueID)
            {
                // Update the quantity
                FoodData updatedFoodData = foodItems[i];
                updatedFoodData.AvailableAmount++;
                foodItems[i] = updatedFoodData;
                return;
            }
        }

        // If food type does not exist, add a new entry
        foodItems.Add(new FoodData { foodType = foodType, AvailableAmount = 1 });
    }

    public FoodTypeSO RemoveFood()
    {
        for (int i = 0; i < foodItems.Count; i++)
        {
            if (foodItems[i].AvailableAmount > 0)
            {
                // Deduct the amount
                FoodData updatedFoodData = foodItems[i];
                updatedFoodData.AvailableAmount--;
                foodItems[i] = updatedFoodData;

                // Return the FoodTypeSO
                return updatedFoodData.foodType;
            }
        }

        // If no valid food was found
        Debug.LogError("No food with enough available amount.");
        return null;
    }

    public int GetTotalFoodAmount()
    {
        int count = 0;
        foreach (var food in foodItems)
        {
            if (food.AvailableAmount > 0)
            {
                count += food.AvailableAmount;
            }
        }
        return count;
    }

    public int GetFoodAmount(FoodTypeSO foodType)
    {
        int foodID = foodType.UniqueID;
        foreach (var food in foodItems)
        {
            if (food.foodType.UniqueID == foodID)
            {
                return food.AvailableAmount;
            }
        }

        return 0;
    }
}
