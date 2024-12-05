using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Factory : Base_Factory
{
    [Header("the Product it creates")]
    [SerializeField] private FoodData Product;

    void Awake()
    {
        ProductType = ProductType.Food;
        TypeEstablishment = TypeEstablishment.Factory;
    }

    protected override void Start()
    {
        base.Start();
        MainManger.instance.EstablishmentHolder.FactoryFoodEstablishments.Add(this);
    }

    public void ProductCreated()
    {
        Product.AvailableAmount++;
    }

    public void SellProducts()
    {
        if (Product.AvailableAmount <= 0) return;
    }
}
