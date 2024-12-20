using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luxury_Factory : Base_Factory
{
    [SerializeField] private LuxeryData _product;

    [ReadOnly]
    [SerializeField] private float _particalyCreatedProduct = 0;

    void Awake()
    {
        ProductType = ProductType.Luxury;
        TypeEstablishment = TypeEstablishment.Factory;
    }

    protected override void Start()
    {
        base.Start();
        MainManger.instance.EstablishmentHolder.FactoryLuxuryEstablishments.Add(this);
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
            DataMangement.instance.Data_Products.AddProductLuxury(_product.LuxuryType.UniqueID, fullyCreatedProducts);
        }
    }

    private void SellProducts()
    {
        if (_product.AvailableAmount <= 0) return;

        foreach (Store_Luxury store in MainManger.instance.EstablishmentHolder.StoreLuxuryEstablishments)
        {
            while (_product.AvailableAmount > 0)
            {
                if (!store.WantedToBuyLuxury(_product.LuxuryType)) break;

                store.BuyOneProduct(_product.LuxuryType);
                int price = _product.LuxuryType.ShopBuyPrice;
                Money += price;
                _Income += price;
                _product.AvailableAmount--;
            }

            if (_product.AvailableAmount <= 0) break;
        }
    }
}
