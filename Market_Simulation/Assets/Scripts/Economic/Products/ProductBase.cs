using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ProductBase : ScriptableObject
{
    [ReadOnly]
    public int UniqueID;

    [Space(20)]
    public string ProductName;
    public int ShopSellPrice;
    public int ShopBuyPrice;

    //[HideInInspector]

    private static int nextId = 0;  // Static counter for generating ID

    void OnValidate()
    {
        // Ensure a unique ID is generated when the ScriptableObject is created
        if (UniqueID == 0)
        {
            UniqueID = nextId++;
        }
    }
}
