using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct ProductAmount
{
    public string Name;
    public List<int> amounts;
}
public class Data_Products : MonoBehaviour
{
    [SerializeField] private List<FoodData> _foodAmounts = new List<FoodData>();
    [SerializeField] private List<LuxeryData> _luxeryAmount = new List<LuxeryData>();

    [HideInInspector] public List<ProductAmount> _Amounts = new List<ProductAmount>();

    void Start()
    {
        MainManger.instance.DayCycle.DayPassed.AddListener(AddToAmounts);
    }

    private void AddToAmounts()
    {
        foreach (FoodData food in _foodAmounts)
        {
            // Find or create an entry for the product
            ProductAmount existingProduct = _Amounts.Find(p => p.Name == food.FoodType.name);

            if (existingProduct.Name == null)
            {
                // Create a new entry if the product does not exist
                ProductAmount newProduct = new ProductAmount
                {
                    Name = food.FoodType.name,
                    amounts = new List<int> { food.AvailableAmount }
                };
                _Amounts.Add(newProduct);
            }
            else
            {
                // Append the new amount to the existing product's list
                int index = _Amounts.FindIndex(p => p.Name == food.FoodType.name);
                _Amounts[index].amounts.Add(food.AvailableAmount);
            }
        }

        // Update LuxeryData amounts
        foreach (LuxeryData luxury in _luxeryAmount)
        {
            // Find or create an entry for the product
            ProductAmount existingProduct = _Amounts.Find(p => p.Name == luxury.LuxuryType.name);

            if (existingProduct.Name == null)
            {
                // Create a new entry if the product does not exist
                ProductAmount newProduct = new ProductAmount
                {
                    Name = luxury.LuxuryType.name,
                    amounts = new List<int> { luxury.AvailableAmount }
                };
                _Amounts.Add(newProduct);
            }
            else
            {
                // Append the new amount to the existing product's list
                int index = _Amounts.FindIndex(p => p.Name == luxury.LuxuryType.name);
                _Amounts[index].amounts.Add(luxury.AvailableAmount);
            }
        }
    }
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
