using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ProductData
{
    public ProductBase ProductType;
    public int AvailableAmount;
}

[Serializable]
public class FoodData : ProductData
{
    public FoodTypeSO FoodType
    {
        get => (FoodTypeSO)base.ProductType;
        set => base.ProductType = value;
    }
}

[Serializable]
public class LuxeryData : ProductData
{
    public Luxury LuxuryType
    {
        get => (Luxury)base.ProductType; 
        set => base.ProductType = value;    
    }
}

[Serializable]
public struct AvailableJobs
{
    public JobsOS job;
    public int AvailableAmount;
}

public enum ProductType
{
    Food,
    Luxury,
}

public enum TypeEstablishment
{
    Factory,
    Store,
    Both,
}

public class Base_Establishment : MonoBehaviour
{
    //What kind of type it produces/sells
    [HideInInspector] public ProductType ProductType;

    //If the establishment is makes products or sells them to people
    [HideInInspector] public TypeEstablishment TypeEstablishment;

    [Space(10)] private float money = 10000;

    public float Money
    {
        get => money;
        set => money = Mathf.Round(value * 100) / 100; // Ensures only two decimal places
    }
}
