using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store_Luxury : Base_Establishment
{
    void Awake()
    {
        ProductType = ProductType.Luxury;
        TypeEstablishment = TypeEstablishment.Store;
    }

    void Start()
    {
        MainManger.instance.EstablishmentHolder.StoreLuxuryEstablishments.Add(this);
    }
}
