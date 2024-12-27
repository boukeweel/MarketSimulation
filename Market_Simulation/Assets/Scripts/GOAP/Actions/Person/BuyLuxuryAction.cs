using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;

public class BuyLuxuryAction : ActionBase<BuyLuxuryAction.Data>
{
    public override void Created()
    {

    }

    public override void Start(IMonoAgent agent, Data data)
    {

    }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        foreach (Store_Luxury luxuryStore in MainManger.instance.EstablishmentHolder.StoreLuxuryEstablishments)
        {
            int Itemindex = luxuryStore.FindITemToBuyPerson(data.wallet.MoneyForLuxuryItem);
            if (Itemindex != -1)
            {
                Luxury LuxuryType = luxuryStore.BuyItemPerons(Itemindex);
                data.Inventory.AddLuxury(LuxuryType);
                float tax = LuxuryType.ShopSellPrice * Goverment.instance.FoodTax;
                Goverment.instance.GetMoney(tax);
                data.wallet.SpendMoney(LuxuryType.ShopSellPrice + tax);
            }
        }

        return ActionRunState.Stop;
    }

    public override void End(IMonoAgent agent, Data data)
    {
        data.Inventory.WantedLuxuryItem = false;
    }
    public class Data : CommonData
    {
        [GetComponent]
        public Inventory Inventory { get; set; }

        [GetComponent]
        public Wallet wallet { get; set; }
    }
}
