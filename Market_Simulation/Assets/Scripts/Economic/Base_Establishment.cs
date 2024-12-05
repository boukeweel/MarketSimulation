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
    public Luxury FoodType
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

    [Space(10)]
    [SerializeField] protected int _money = 10000;
}
