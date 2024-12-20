using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Resolver;
using UnityEditor;
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
        //hunger
        builder.AddGoal<EatGoal>()
            .AddCondition<Hunger>(Comparison.SmallerThanOrEqual, Injector.BioSign.AcceptableHungerLimit);

        //jobs
        builder.AddGoal<WorkGoal>()
            .AddCondition<NeedsToWork>(Comparison.SmallerThanOrEqual, 0);

        //luxury
        builder.AddGoal<BuyLuxuryGoal>()
            .AddCondition<BuyingLuxury>(Comparison.SmallerThanOrEqual, 0);
    }

    private void BuildAction(GoapSetBuilder builder)
    {
        //hunger
        builder.AddAction<EatAction>()
            .AddEffect<Hunger>(EffectType.Decrease)
            .AddCondition<HasFood>(Comparison.GreaterThan, 0)
            .SetBaseCost(5);
        builder.AddAction<BuyFood>()
            .AddEffect<HasFood>(EffectType.Increase)
            .SetBaseCost(5);

        //jobs
        builder.AddAction<WorkAction>()
            .AddEffect<NeedsToWork>(EffectType.Decrease)
            .AddCondition<NeedsToGetWork>(Comparison.SmallerThanOrEqual, 0)
            .SetBaseCost(5);
        builder.AddAction<GetAJobAction>()
            .AddEffect<NeedsToGetWork>(EffectType.Decrease)
            .SetBaseCost(5);

        //luxury
        builder.AddAction<BuyLuxuryAction>()
            .AddEffect<BuyingLuxury>(EffectType.Decrease)
            .SetBaseCost(5);
    }

    private void BuildSensors(GoapSetBuilder builder)
    {
        //hunger
        builder.AddWorldSensor<HungerSensor>()
            .SetKey<Hunger>();
        builder.AddWorldSensor<HasFoodSensor>()
            .SetKey<HasFood>();

        //jobs
        builder.AddWorldSensor<WorkSensor>()
            .SetKey<NeedsToWork>();
        builder.AddWorldSensor<HasJobSensor>()
            .SetKey<NeedsToGetWork>();

        //luxury
        builder.AddWorldSensor<BuyLuxurySensor>()
            .SetKey<BuyingLuxury>();
    }
}
