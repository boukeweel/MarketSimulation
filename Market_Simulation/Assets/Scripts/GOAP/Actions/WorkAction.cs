using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;

public class WorkAction : ActionBase<WorkAction.Data>
{
    public override void Start(IMonoAgent agent, Data data)
    { }
    public override void Created()
    { }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if (data._brain.InWorkHours() == 0)
        {
            return ActionRunState.Stop;
        }

        return ActionRunState.Continue;
    }

    public override void End(IMonoAgent agent, Data data)
    {
        
    }


    public class Data : CommonData
    {
        [GetComponent] 
        public PersonBrian _brain { get; set; }
    }
}
