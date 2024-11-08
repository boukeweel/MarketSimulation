using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using UnityEngine;


[RequireComponent(typeof(AgentBehaviour))]
public class GoapSetBinder : MonoBehaviour
{
    [SerializeField] private GoapRunnerBehaviour _goapRunner;

    void Awake()
    {
        AgentBehaviour agent = GetComponent<AgentBehaviour>();
        agent.GoapSet = _goapRunner.GetGoapSet("Person");
    }
}
