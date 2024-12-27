using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_People : MonoBehaviour
{ 
    public List<GameObject> People = new List<GameObject>();
    public int PeopleCount = 0;

    [Header("List for average wealth and total wealth for book keeping")]
    public List<float> AveragesWealthsPeople = new List<float>();
    public List<float> TotalWealthsPeople = new List<float>();

    [Header("Average and total wealth per day")]
    public float AveragesWealthPeople = 0;
    public float TotalWealthPeople = 0;

    void Start()
    {
        MainManger.instance.DayCycle.DayPassed.AddListener(CalculatedPeopleWealth);
    }

    void CalculatedPeopleWealth()
    {
        PeopleCount = People.Count;
        TotalWealthPeople = 0;
        foreach (GameObject Person in People)
        {
            TotalWealthPeople += Person.GetComponent<Wallet>().Money;
        }
        AveragesWealthPeople = TotalWealthPeople / PeopleCount;

        AveragesWealthsPeople.Add(AveragesWealthPeople);
        TotalWealthsPeople.Add(TotalWealthPeople);
    }
}
