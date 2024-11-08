using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Resolver;
using UnityEngine;

public class GoapSetConfigFactory : GoapSetFactoryBase
{
    public override IGoapSetConfig Create()
    {
        GoapSetBuilder builder = new("Person");

        BuildGoals(builder);
        BuildAction(builder);
        BuildSensors(builder);

        return builder.Build();
    }

    private void BuildGoals(GoapSetBuilder builder)
    {
        builder.AddGoal<EatGoal>()
            .AddCondition<Hunger>(Comparison.SmallerThanOrEqual, 0);
    }

    private void BuildAction(GoapSetBuilder builder)
    {
        builder.AddAction<EatAction>()
            .AddEffect<Hunger>(EffectType.Decrease)
            .SetBaseCost(8);
    }

    private void BuildSensors(GoapSetBuilder builder)
    {
        builder.AddWorldSensor<HungerSensor>()
            .SetKey<Hunger>();
    }
}
