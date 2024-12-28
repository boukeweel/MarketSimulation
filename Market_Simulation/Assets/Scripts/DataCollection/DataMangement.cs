using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMangement : MonoBehaviour
{
    public static DataMangement instance;

    [HideInInspector]
    public Data_Products Data_Products;
    [HideInInspector]
    public Data_People Data_People;
    [HideInInspector]
    public Data_Establishments Data_Establishments;

    void Awake()
    {
        instance = this;
        Data_Products = GetComponent<Data_Products>();
        Data_People = GetComponent<Data_People>();
        Data_Establishments = GetComponent<Data_Establishments>();
    }
}
