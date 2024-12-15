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

    void Awake()
    {
        instance = this;
        Data_Products = GetComponent<Data_Products>();
        Data_People = GetComponent<Data_People>();
    }
}
