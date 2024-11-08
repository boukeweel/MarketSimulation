using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerBavhior : MonoBehaviour
{
    [field: SerializeField] public float Hunger { get;  set; }
    [SerializeField] private BioSignSO _bioSign;
    void Awake()
    {
        Hunger = Random.Range(0, _bioSign.MaxHunger);
    }

    void Update()
    {
        Hunger += Time.deltaTime * _bioSign.HungerDepletionRate;
    }
}
