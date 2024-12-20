using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store_Luxury : Base_Establishment
{
    public List<LuxeryData> luxeryTypes = new List<LuxeryData>();

    private int MaxAmountOfOneFoodType = 10;


    void Awake()
    {
        ProductType = ProductType.Luxury;
        TypeEstablishment = TypeEstablishment.Store;
    }

    void Start()
    {
        MainManger.instance.EstablishmentHolder.StoreLuxuryEstablishments.Add(this);
    }

    public int FindITemToBuyPerson(int budget)
    {
        for (int i = 0; i < luxeryTypes.Count; i++)
        {
            if (luxeryTypes[i].LuxuryType.ShopSellPrice < budget && luxeryTypes[i].AvailableAmount > 0)
            {
                return i;
            }
        }

        return -1;
    }
    public Luxury BuyItemPerons(int index)
    {
        if (index >= 0 && index < luxeryTypes.Count)
        {
            LuxeryData Luxery = luxeryTypes[index];

            if (Luxery.AvailableAmount > 0)
            {
                Luxery.AvailableAmount--;
                luxeryTypes[index] = Luxery;
                Money += Luxery.LuxuryType.ShopSellPrice;
                return Luxery.LuxuryType;
            }
        }
        return null;
    }

    public bool WantedToBuyLuxury(Luxury type)
    {
        if (type.ShopBuyPrice > Money) return false;

        foreach (LuxeryData luxarData in luxeryTypes)
        {
            if (luxarData.LuxuryType.UniqueID == type.UniqueID)
            {
                if (luxarData.AvailableAmount >= MaxAmountOfOneFoodType) return false;
            }
        }
        return true;
    }
    public void BuyOneProduct(Luxury foodType)
    {
        for (int i = 0; i < luxeryTypes.Count; i++)
        {
            if (luxeryTypes[i].LuxuryType.UniqueID == foodType.UniqueID)
            {
                LuxeryData foodData = luxeryTypes[i];
                foodData.AvailableAmount++;
                luxeryTypes[i] = foodData;
                Money -= foodData.ProductType.ShopBuyPrice;
                return;
            }
        }

        LuxeryData newLuxeryData = new LuxeryData { };
        newLuxeryData.LuxuryType = foodType;
        newLuxeryData.AvailableAmount++;
        Money -= newLuxeryData.ProductType.ShopBuyPrice;
        luxeryTypes.Add(newLuxeryData);
    }
}
