using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "AI/BioSigns Config",fileName = "BioSigns Config",order = 1)]
public class BioSignSO : ScriptableObject
{
    public float HungerDepletionRate = 0.25f;
    public float MaxHunger = 20f;
    public int AcceptableHungerLimit = 10;
}
