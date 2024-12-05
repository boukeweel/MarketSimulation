using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManger : MonoBehaviour
{
    public static MainManger instance;

    [HideInInspector]
    public DayCycle DayCycle;
    [HideInInspector]
    public EstablishmentHolder EstablishmentHolder;

    void Awake()
    {
        instance = this;
        DayCycle = GetComponent<DayCycle>();
        EstablishmentHolder = GetComponent<EstablishmentHolder>();
    }
}
