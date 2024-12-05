using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using Unity.VisualScripting;
using UnityEngine;

public class PersonBrian : MonoBehaviour
{
    private HungerBavhior _hunger;
    private BioSignSO _biosign;
    [SerializeField] private JobsOS _currentJob;
    private AgentBehaviour _agentBehaviour;
    private DayCycle _dayCycle;

    //bad
    public Store_Food FoodStore;
    public int PrefferdFoodQuality = 1;

    void Awake()
    {
        _agentBehaviour = GetComponent<AgentBehaviour>();
        _hunger = GetComponent<HungerBavhior>();
        _biosign = _hunger.BioSign;
    }

    void Start()
    {
        _dayCycle = MainManger.instance.DayCycle;
    }
    private void Update()
    {
        if (_currentJob != null)
        {
            if (InWorkHours() == 1)
            {
                _agentBehaviour.SetGoal<WorkGoal>(true);
            }
        }
        if (_hunger.Hunger >= _biosign.MaxHunger)
        {
            _agentBehaviour.SetGoal<EatGoal>(true);
        }
    }

    public int InWorkHours()
    {
        if (_dayCycle.Hours >= _currentJob.StartingHours && _dayCycle.Hours <= _currentJob.EndingHours)
            return 1;
        return 0;
    }
}
