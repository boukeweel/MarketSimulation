using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Products/FoodTypes", fileName = "Food Type")]
public class FoodTypeSO : ProductBase
{
    [Range(1, 10)]
    public int Quality;
    public float Nutrition;
}
