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
    private BioSignSO bioSign;

    public override void Created()
    {
    }

    public override void Start(IMonoAgent agent, Data data)
    {
        data.Hunger.enabled = false;
        data.timer = 1f;

    }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        data.timer -= context.DeltaTime;

        if (data.Target == null || data.Hunger.Hunger <= 0)
        {
            return ActionRunState.Stop;
        }

        return ActionRunState.Continue;
    }

    public override void End(IMonoAgent agent, Data data)
    {
        data.Hunger.Hunger = 0;
        data.Hunger.enabled = true;
    }

    public class Data : CommonData
    {
        [GetComponent]
        public HungerBavhior Hunger { get; set; }
    }
}
