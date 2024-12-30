using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food_Factory : Base_Factory
{
    [Header("the _product it creates")]
    [SerializeField] private FoodData _product;

    [ReadOnly]
    [SerializeField]private float _particalyCreatedProduct;

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

    public void ProductCreated(float Amount)
    {
        _particalyCreatedProduct += Amount;

        int fullyCreatedProducts = Mathf.FloorToInt(_particalyCreatedProduct);

        _particalyCreatedProduct -= fullyCreatedProducts;

        if (fullyCreatedProducts > 0)
        {
            _product.AvailableAmount += fullyCreatedProducts;
            DataMangement.instance.Data_Products.AddProductFood(_product.FoodType.UniqueID, fullyCreatedProducts);
        }
    }

    private void SellProducts()
    {
        if (_product.AvailableAmount <= 0) return;

        foreach (Store_Food store in MainManger.instance.EstablishmentHolder.StoreFoodEstablishments)
        {
            while (_product.AvailableAmount > 0)
            {
                if (!store.WantedToBuyFood(_product.FoodType)) break;

                store.BuyOneProduct(_product.FoodType);
                _product.AvailableAmount--;

                int price = _product.FoodType.ShopBuyPrice;
                Money += price;
                _Income += price;
            }

            if (_product.AvailableAmount <= 0) break;
        }
    }
}
