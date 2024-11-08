using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Job config", fileName = "BasicJob", order = 1)]
public class JobsOS : ScriptableObject
{
    public int Salary;
    public float WorkHours;

    public float StartingHour = 9;
    public float EndingHour = 17;
}
