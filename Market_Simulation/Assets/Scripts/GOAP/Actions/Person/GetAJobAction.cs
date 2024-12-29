using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;

public class GetAJobAction : ActionBase<GetAJobAction.Data>
{
    public override void Start(IMonoAgent agent, Data data) { }
    public override void Created() { }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if (data._Emploment.HasJob() == 1)
        {
            foreach (Food_Factory factory in MainManger.instance.EstablishmentHolder.FactoryFoodEstablishments)
            {
                if (factory.Jobs.AvailableAmount > 0)
                {
                    factory.HireEmploy(data._Emploment);
                    return ActionRunState.Stop;
                }
            }

            foreach (Luxury_Factory factory in MainManger.instance.EstablishmentHolder.FactoryLuxuryEstablishments)
            {
                if (factory.Jobs.AvailableAmount > 0)
                {
                    factory.HireEmploy(data._Emploment);
                    return ActionRunState.Stop;
                }
            }

            if (MainManger.instance.EstablishmentHolder.Goverment.Jobs.AvailableAmount > 0)
            {
                MainManger.instance.EstablishmentHolder.Goverment.HireEmploy(data._Emploment);
                return ActionRunState.Stop;
            }
        }

        return ActionRunState.Continue;
    }

    public override void End(IMonoAgent agent, Data data) { }

    public class Data : CommonData
    {
        [GetComponent]
        public Emploment _Emploment { get; set; }
    }
}
