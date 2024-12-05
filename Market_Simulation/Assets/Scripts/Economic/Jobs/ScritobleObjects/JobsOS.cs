using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Job config", fileName = "BasicJob", order = 1)]
public class JobsOS : ScriptableObject
{
    public float StartingHours;
    public float EndingHours;
}