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

    public int FindITemToBuyPerson(float budget)
    {
        for (int i = 0; i < luxeryTypes.Count; i++)
        {
            if (luxeryTypes[i].LuxuryType.ShopSellPrice + (luxeryTypes[i].LuxuryType.ShopSellPrice * Goverment.instance.LuxuryTax) < budget && luxeryTypes[i].AvailableAmount > 0)
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
    public void BuyOneProduct(Luxury luxuryType)
    {
        float tax = 0;
        for (int i = 0; i < luxeryTypes.Count; i++)
        {
            if (luxeryTypes[i].LuxuryType.UniqueID == luxuryType.UniqueID)
            {
                LuxeryData luxuryData = luxeryTypes[i];
                luxuryData.AvailableAmount++;
                luxeryTypes[i] = luxuryData;
                tax = luxuryData.ProductType.ShopBuyPrice * Goverment.instance.FactoryTax;
                Goverment.instance.GetMoney(tax);
                Money -= luxuryData.ProductType.ShopBuyPrice + tax;
                return;
            }
        }

        LuxeryData newLuxeryData = new LuxeryData { };
        newLuxeryData.LuxuryType = luxuryType;
        newLuxeryData.AvailableAmount++;
        tax = newLuxeryData.ProductType.ShopBuyPrice * Goverment.instance.FactoryTax;
        Goverment.instance.GetMoney(tax);
        Money -= newLuxeryData.ProductType.ShopBuyPrice + tax;
        luxeryTypes.Add(newLuxeryData);
    }
}
