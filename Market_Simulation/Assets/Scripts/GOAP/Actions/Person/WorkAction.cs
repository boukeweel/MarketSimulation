using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;

public class WorkAction : ActionBase<WorkAction.Data>
{
    private bool _endWorkDay;

    public override void Created()
    { }
    public override void Start(IMonoAgent agent, Data data)
    {
        _endWorkDay = false;
        data._Emploment.EndWorkDay.AddListener(EndWorkDay);
    }
    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if (data._Emploment.InWorkHours() == 0)
        {
            return ActionRunState.Stop;
        }
        return ActionRunState.Continue;
    }
    public override void End(IMonoAgent agent, Data data)
    {
        if (_endWorkDay && data._Emploment.CurrentWork != null && data._Emploment.CurrentJob != null)
        {
            float AmountProduct = Random.Range(data._Emploment.CurrentJob.MinProductsCreatedInDay, data._Emploment.CurrentJob.MaxProductsCreatedInDay);

            if (data._Emploment.CurrentWork.ProductType == ProductType.Food)
            {
                Food_Factory food_factory = (Food_Factory)data._Emploment.CurrentWork;
                food_factory.ProductCreated(AmountProduct);
            }
            else if (data._Emploment.CurrentWork.ProductType == ProductType.Luxury)
            {
                Luxury_Factory luxury_Factory = (Luxury_Factory)data._Emploment.CurrentWork;
                luxury_Factory.ProductCreated(AmountProduct);
            }
        }
        
        data._Emploment.EndWorkDay.RemoveListener(EndWorkDay);
    }

    private void EndWorkDay()
    {
        _endWorkDay = true;
    }

    public class Data : CommonData
    {
        [GetComponent]
        public Emploment _Emploment { get; set; }

    }
}
