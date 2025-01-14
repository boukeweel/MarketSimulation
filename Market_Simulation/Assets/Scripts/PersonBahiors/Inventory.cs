using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<FoodData> foodItems = new List<FoodData>();
    [SerializeField] private List<LuxeryData> luxeryItems = new List<LuxeryData>();

    public bool WantedLuxuryItem = false;

    public void AddFood(FoodTypeSO foodType)
    {
        for (int i = 0; i < foodItems.Count; i++)
        {
            if (foodItems[i].ProductType.UniqueID == foodType.UniqueID)
            {
                // Update the quantity
                FoodData updatedProductData = foodItems[i];
                updatedProductData.AvailableAmount++;
                foodItems[i] = updatedProductData;
                return;
            }
        }

        // If food type does not exist, add a new entry
        foodItems.Add(new FoodData { ProductType = foodType, AvailableAmount = 1 });
    }
    public FoodTypeSO RemoveFood()
    {
        for (int i = 0; i < foodItems.Count; i++)
        {
            if (foodItems[i].AvailableAmount > 0)
            {
                foodItems[i].AvailableAmount--;
                DataMangement.instance.Data_Products.RemoveProductFood(foodItems[i].FoodType.UniqueID);

                // Return the FoodTypeSO
                return foodItems[i].FoodType;
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
    public int GetFoodAmount(int UniqueID)
    {
        foreach (var food in foodItems)
        {
            if (food.ProductType.UniqueID == UniqueID)
            {
                return food.AvailableAmount;
            }
        }

        return 0;
    }

    public void AddLuxury(Luxury luxury)
    {
        for (int i = 0; i < luxeryItems.Count; i++)
        {
            if (luxeryItems[i].ProductType.UniqueID == luxury.UniqueID)
            {
                // Update the quantity
                luxeryItems[i].AvailableAmount++;
                DataMangement.instance.Data_Products.RemoveProductLuxury(luxury.UniqueID);
                return;
            }
        }

        // If food type does not exist, add a new entry
        luxeryItems.Add(new LuxeryData { ProductType = luxury, AvailableAmount = 1 });
        DataMangement.instance.Data_Products.RemoveProductLuxury(luxury.UniqueID);
    }
    public int WantLuxury()
    {
       if(WantedLuxuryItem)
           return 1;

       return 0;
    }
    public int GetLuxuryAmount(int UniqueID)
    {
        foreach (LuxeryData luxury in luxeryItems)
        {
            if (luxury.ProductType.UniqueID == UniqueID)
            {
                return luxury.AvailableAmount;
            }
        }

        return 0;
    }


    public void SetWantLuxuryItem()
    {
        WantedLuxuryItem = true;
    }
}
