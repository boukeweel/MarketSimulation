using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        MainManger.instance.DayCycle.DayPassed.AddListener(SellProducts);
    }

    public void ProductCreated()
    {
        Product.AvailableAmount++;
    }

    private void SellProducts()
    {
        if (Product.AvailableAmount <= 0) return;

        foreach (Store_Food store in MainManger.instance.EstablishmentHolder.StoreFoodEstablishments)
        {
            while (Product.AvailableAmount > 0)
            {
                if (!store.WantedToBuyFood(Product.FoodType)) break;

                store.BuyOneProduct(Product.FoodType);
                _money += Product.FoodType.ShopBuyPrice;
                Product.AvailableAmount--;

                Debug.Log("Sold Product");
            }

            if (Product.AvailableAmount <= 0) break;
        }
    }
}
