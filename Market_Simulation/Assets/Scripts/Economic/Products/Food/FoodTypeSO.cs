using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/FoodTypes", fileName = "Food Type", order = 2)]
public class FoodTypeSO : ScriptableObject
{
    [Range(1, 10)]
    public int Quality;
    public int Price;
    public float Nutrition;

    [HideInInspector]
    public int UniqueID;

    private static int nextId = 0;  // Static counter for generating IDs

    private void OnEnable()
    {
        // Ensure a unique ID is generated when the ScriptableObject is created
        if (UniqueID == 0)
        {
            UniqueID = nextId++;
        }
    }
}
