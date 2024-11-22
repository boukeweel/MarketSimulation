using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;

public class DependencyInjector : GoapConfigInitializerBase, IGoapInjector
{
    public BioSignSO BioSign;

    public override void InitConfig(GoapConfig config)
    {
        config.GoapInjector = this;
    }

    public void Inject(IGoalBase goal)
    {
        if (goal is IInjectabol injectabol)
        {
            injectabol.Inject(this);
        }
    }

    public void Inject(IActionBase action)
    {
        if (action is IInjectabol injectabol)
        {
            injectabol.Inject(this);
        }
    }

    public void Inject(ITargetSensor targetSensor)
    {
        if (targetSensor is IInjectabol injectabol)
        {
            injectabol.Inject(this);
        }

    }

    public void Inject(IWorldSensor worldSensor)
    {
        if (worldSensor is IInjectabol injectabol)
        {
            injectabol.Inject(this);
        }

    }
}
