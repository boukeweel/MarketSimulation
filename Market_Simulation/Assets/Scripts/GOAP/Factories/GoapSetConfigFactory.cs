using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Resolver;
using UnityEngine;


[RequireComponent(typeof(DependencyInjector))]
public class GoapSetConfigFactory : GoapSetFactoryBase
{

    private DependencyInjector Injector;
    public override IGoapSetConfig Create()
    {
        Injector = GetComponent<DependencyInjector>();
        GoapSetBuilder builder = new("Person");

        BuildGoals(builder);
        BuildAction(builder);
        BuildSensors(builder);

        return builder.Build();
    }

    private void BuildGoals(GoapSetBuilder builder)
    {
        builder.AddGoal<EatGoal>()
            .AddCondition<Hunger>(Comparison.SmallerThanOrEqual, Injector.BioSign.AcceptableHungerLimit);
        builder.AddGoal<WorkGoal>()
            .AddCondition<NeedsToWork>(Comparison.SmallerThanOrEqual, 0);
    }

    private void BuildAction(GoapSetBuilder builder)
    {
        builder.AddAction<EatAction>()
            .AddEffect<Hunger>(EffectType.Decrease)
            .AddCondition<HasFood>(Comparison.GreaterThan, 0)
            .SetBaseCost(5);
        builder.AddAction<BuyFood>()
            .AddEffect<HasFood>(EffectType.Increase)
            .SetBaseCost(5);
        builder.AddAction<WorkAction>()
            .AddEffect<NeedsToWork>(EffectType.Decrease)
            .SetBaseCost(2);
    }

    private void BuildSensors(GoapSetBuilder builder)
    {
        builder.AddWorldSensor<HungerSensor>()
            .SetKey<Hunger>();
        builder.AddWorldSensor<HasFoodSensor>()
            .SetKey<HasFood>();
        builder.AddWorldSensor<WorkSensor>()
            .SetKey<NeedsToWork>();
    }
}
