using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;

public class EatAction : ActionBase<EatAction.Data>
{

    public override void Created()
    {
    }

    public override void Start(IMonoAgent agent, Data data)
    {
        data.Hunger.enabled = false;
    }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if (data.Hunger.Hunger <= data.Hunger.BioSign.AcceptableHungerLimit)
        {
            return ActionRunState.Stop;
        }

        if (data.Inventory.GetTotalFoodAmount() > 0)
        {
            FoodTypeSO food = data.Inventory.RemoveFood();
            data.Hunger.Hunger -= food.Nutrition;
        }
        else
        {
            return ActionRunState.Stop;
        }

        return ActionRunState.Continue;
    }

    public override void End(IMonoAgent agent, Data data)
    {
        data.Hunger.enabled = true;
    }

    public class Data : CommonData
    {
        [GetComponent]
        public HungerBavhior Hunger { get; set; }
        [GetComponent]
        public Inventory Inventory { get; set; }
    }
}
