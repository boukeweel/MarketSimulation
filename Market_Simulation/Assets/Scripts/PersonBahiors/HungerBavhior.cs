using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HungerBavhior : MonoBehaviour
{
    [field: SerializeField] public float Hunger { get; set; }
    public BioSignSO BioSign;

    void Awake()
    {
        Hunger = Random.Range(0, 10);
    }

    void Start()
    {
        MainManger.instance.DayCycle.HourPassed.AddListener(AddHunger);
    }

    private void AddHunger()
    {
        Hunger += BioSign.HungerDepletionRate;

        Hunger = Mathf.Clamp(Hunger, 0, BioSign.MaxHunger);
    }

}
