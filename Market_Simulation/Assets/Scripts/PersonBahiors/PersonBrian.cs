using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using Unity.VisualScripting;
using UnityEngine;

public class PersonBrian : MonoBehaviour
{
    [SerializeField] private HungerBavhior _hunger;
    [SerializeField] private BioSignSO _biosign;
    private AgentBehaviour _agentBehaviour;


    void Awake()
    {
        _agentBehaviour = GetComponent<AgentBehaviour>();
    }


    private void Update()
    {
        if (_hunger.Hunger > _biosign.MaxHunger)
        {
            _agentBehaviour.SetGoal<EatGoal>(true);
        }
    }
}
