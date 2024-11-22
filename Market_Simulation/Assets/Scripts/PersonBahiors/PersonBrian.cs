using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using Unity.VisualScripting;
using UnityEngine;

public class PersonBrian : MonoBehaviour
{
    private HungerBavhior _hunger;
    private BioSignSO _biosign;
    private AgentBehaviour _agentBehaviour;

    //bad
    public Store_Food FoodStore;
    public int PrefferdFoodQuality = 1;

    void Awake()
    {
        _agentBehaviour = GetComponent<AgentBehaviour>();
        _hunger = GetComponent<HungerBavhior>();
        _biosign = _hunger.BioSign;
    }


    private void Update()
    {
        if (_hunger.Hunger >= _biosign.MaxHunger)
        {
            _agentBehaviour.SetGoal<EatGoal>(true);
        }
    }
}
