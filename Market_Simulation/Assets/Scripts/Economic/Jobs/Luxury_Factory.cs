using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luxury_Factory : Base_Factory
{
    [SerializeField] private LuxeryData _product;
    void Awake()
    {
        ProductType = ProductType.Food;
        TypeEstablishment = TypeEstablishment.Factory;
    }

    protected override void Start()
    {
        base.Start();
        MainManger.instance.EstablishmentHolder.FactoryLuxuryEstablishments.Add(this);
    }
    public void ProductCreated(int Amount)
    {
        _product.AvailableAmount += Amount;
    }
}
