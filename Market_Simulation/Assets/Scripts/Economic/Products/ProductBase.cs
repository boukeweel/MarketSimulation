using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductBase : ScriptableObject
{
    public string ProductName;
    public int ShopSellPrice;
    public int ShopBuyPrice;

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
