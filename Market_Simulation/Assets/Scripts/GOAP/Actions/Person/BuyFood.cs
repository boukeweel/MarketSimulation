using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;

public class BuyFood : ActionBase<BuyFood.Data>
{
    public override void Created()
    { }

    public override void Start(IMonoAgent agent, Data data)
    { }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if (data.Inventory.GetTotalFoodAmount() >= 2)
        {
            return ActionRunState.Stop;
        }

        foreach (Store_Food foodStore in MainManger.instance.EstablishmentHolder.StoreFoodEstablishments)
        {
            int foodindex = foodStore.FindFoodToBuyPerson(data.wallet.Savings, data.Brain.PrefferdFoodQuality);
            if (foodindex != -1)
            {
                FoodTypeSO foodType = foodStore.BuyFoodPerson(foodindex);
                data.Inventory.AddFood(foodType);
                data.wallet.SpendMoney(foodType.ShopSellPrice);
                data.Brain.PrefferdFoodQuality = foodType.Quality;
            }
        }

        return ActionRunState.Continue;
    }

    public override void End(IMonoAgent agent, Data data)
    { }

    public class Data : CommonData
    {
        [GetComponent]
        public PersonBrian Brain { get; set; }

        [GetComponent]
        public Inventory Inventory { get; set; }

        [GetComponent]
        public Wallet wallet { get; set; }
    }
}
