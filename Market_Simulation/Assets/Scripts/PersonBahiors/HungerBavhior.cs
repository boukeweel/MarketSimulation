using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerBavhior : MonoBehaviour
{
    [field: SerializeField] public float Hunger { get; set; }
    public BioSignSO BioSign;


    void Awake()
    {
        Hunger = Random.Range(0, BioSign.MaxHunger);
    }

    void Update()
    {
        Hunger += Time.deltaTime * BioSign.HungerDepletionRate;
    }

}
