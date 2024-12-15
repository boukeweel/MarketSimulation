using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Products : MonoBehaviour
{
    [SerializeField] private List<FoodData> _foodAmounts = new List<FoodData>();
    [SerializeField] private List<LuxeryData> _luxeryAmount = new List<LuxeryData>();

    public void AddProductFood(int uniqueID, int Amount = 1)
    {
        foreach (FoodData FoodData in _foodAmounts)
        {
            if (FoodData.FoodType.UniqueID == uniqueID)
            {
                FoodData.AvailableAmount += Amount;
                return;
            }
        }
    }
    public void RemoveProductFood(int uniqueID, int Amount = 1)
    {
        foreach (FoodData FoodData in _foodAmounts)
        {
            if (FoodData.FoodType.UniqueID == uniqueID)
            {
                FoodData.AvailableAmount -= Amount;
                return;
            }
        }
    }

    public void AddProductLuxury(int uniqueID, int Amount = 1)
    {
        foreach (LuxeryData luxeryData in _luxeryAmount)
        {
            if (luxeryData.LuxuryType.UniqueID == uniqueID)
            {
                luxeryData.AvailableAmount += Amount;
                return;
            }
        }
    }
    public void RemoveProductLuxury(int uniqueID, int Amount = 1)
    {
        foreach (LuxeryData luxeryData in _luxeryAmount)
        {
            if (luxeryData.LuxuryType.UniqueID == uniqueID)
            {
                luxeryData.AvailableAmount -= Amount;
                return;
            }
        }
    }
}
