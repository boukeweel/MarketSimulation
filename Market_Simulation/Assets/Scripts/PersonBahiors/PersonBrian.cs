using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PersonBrian : MonoBehaviour
{
    private HungerBavhior _hunger;
    private BioSignSO _biosign;
    private AgentBehaviour _agentBehaviour;
    private Emploment _emploment;
    private Inventory _inventory;

    public int PrefferdFoodQuality = 1;

    void Awake()
    {
        _agentBehaviour = GetComponent<AgentBehaviour>();
        _hunger = GetComponent<HungerBavhior>();
        _emploment = GetComponent<Emploment>();
        _inventory = GetComponent<Inventory>();
        _biosign = _hunger.BioSign;
    }

    void Start()
    {
        DataMangement.instance.Data_People.People.Add(this.gameObject);
        MainManger.instance.DayCycle.DayPassed.AddListener(_inventory.SetWantLuxuryItem);
    }
    private void Update()
    {
        if (_inventory.WantLuxury() == 1)
        {
            _agentBehaviour.SetGoal<BuyLuxuryGoal>(true);
        }

        if (_emploment.InWorkHours() == 1)
        {
            _agentBehaviour.SetGoal<WorkGoal>(true);
        }
        
        if (_hunger.Hunger >= _biosign.MaxHunger)
        {
            _agentBehaviour.SetGoal<EatGoal>(true);
        }
    }

    
}
