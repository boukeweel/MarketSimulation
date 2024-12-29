using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        SaveListsToFiles();
    }

    private void SaveListsToFiles()
    {
        SaveListToFile("TotalWealthsEstablishments.txt",
            DataMangement.instance.Data_Establishments.TotalWealthsEstablishments);
        SaveListToFile("AveragesWealthsEstablishments.txt",
            DataMangement.instance.Data_Establishments.AveragesWealthsEstablishments);

        // Save lists related to Food Factories
        SaveListToFile("TotalWealthsFoodFactories.txt",
            DataMangement.instance.Data_Establishments.TotalWealthsFoodFactories);
        SaveListToFile("AveragesWealthsFoodFactories.txt",
            DataMangement.instance.Data_Establishments.AveragesWealthsFoodFactories);

        // Save lists related to Luxury Factories
        SaveListToFile("TotalWealthsLuxuryFactories.txt",
            DataMangement.instance.Data_Establishments.TotalWealthsLuxuryFactories);
        SaveListToFile("AveragesWealthsLuxuryFactories.txt",
            DataMangement.instance.Data_Establishments.AveragesWealthsLuxuryFactories);

        // Save lists related to Food Stores
        SaveListToFile("TotalWealthsFoodStores.txt", DataMangement.instance.Data_Establishments.TotalWealthsFoodStores);
        SaveListToFile("AveragesWealthsFoodStores.txt",
            DataMangement.instance.Data_Establishments.AveragesWealthsFoodStores);

        // Save lists related to Luxury Stores
        SaveListToFile("TotalWealthsLuxuryStores.txt",
            DataMangement.instance.Data_Establishments.TotalWealthsLuxuryStores);
        SaveListToFile("AveragesWealthsLuxuryStores.txt",
            DataMangement.instance.Data_Establishments.AveragesWealthsLuxuryStores);

        //save list of people wealths
        SaveListToFile("TotalWealthPeople.txt", DataMangement.instance.Data_People.TotalWealthsPeople);
        SaveListToFile("AveragesWealthsPeople.txt", DataMangement.instance.Data_People.AveragesWealthsPeople);

        SaveListToFile("GovermentFunds.txt", Goverment.instance.Moneys);

        SaveProductAmountsToFiles();
    }

    private void SaveProductAmountsToFiles()
    {
        foreach (ProductAmount product in DataMangement.instance.Data_Products._Amounts)
        {
            // Generate a file name based on the product name
            string fileName = $"Data/{product.Name}_Amounts.txt";
            string filePath = Path.Combine(Application.dataPath, fileName);

            // Write the amounts to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int amount in product.amounts)
                {
                    writer.WriteLine(amount);
                }
            }

            Debug.Log($"Saved {fileName} with {product.amounts.Count} entries at {filePath}");
        }
    }

    private void SaveListToFile(string fileName, List<float> dataList)
    {
        // Combine path to save the file in the project directory
        string fileNameFolder = Path.Combine("Data/", fileName);
        string filePath = Path.Combine(Application.dataPath, fileNameFolder);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (float value in dataList)
            {
                // If the value is an integer, write it without decimal places
                if (value == (int)value)
                {
                    writer.WriteLine(value.ToString("0"));
                }
                else
                {
                    // Otherwise, format the value with one decimal place and replace dot with a comma
                    string formattedValue = value.ToString("0.0").Replace('.', ',');
                    writer.WriteLine(formattedValue);
                }
            }
        }

        Debug.Log($"Saved {fileName} with {dataList.Count} entries at {filePath}");
    }
}

