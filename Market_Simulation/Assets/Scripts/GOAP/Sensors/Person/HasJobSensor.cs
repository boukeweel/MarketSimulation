using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
public class HasJobSensor : LocalWorldSensorBase
{
    public override void Created() { }

    public override void Update() { }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        return new SenseValue(references.GetCachedComponent<Emploment>().HasJob());
    }
}
