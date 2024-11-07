using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

public class CostAnalysisItem
{
    [JsonProperty("YearId")]
    public string? YearId { get; set; }

    [JsonProperty("GeoRegionId")]
    public int GeoRegionId { get; set; }

    [JsonProperty("CountryId")]
    public int CountryId { get; set; }

    [JsonProperty("RegionId")]
    public int RegionId { get; set; }

    [JsonProperty("SchemeId")]
    public int SchemeId { get; set; }

    [JsonProperty("SchmTypeId")]
    public int SchmTypeId { get; set; }

    [JsonProperty("Cost")]
    public double Cost { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Instantiate a list of CostAnalysisItem objects and add sample data
        List<CostAnalysisItem> items = new List<CostAnalysisItem>
        {
            new CostAnalysisItem { YearId = "2016", GeoRegionId = 1, CountryId = 101, RegionId = 1, SchemeId = 1, SchmTypeId = 1, Cost = 5000 },
            new CostAnalysisItem { YearId = "2016", GeoRegionId = 1, CountryId = 102, RegionId = 2, SchemeId = 1, SchmTypeId = 1, Cost = 7000 },
            new CostAnalysisItem { YearId = "2017", GeoRegionId = 2, CountryId = 103, RegionId = 3, SchemeId = 2, SchmTypeId = 2, Cost = 15000 },
            new CostAnalysisItem { YearId = "2016", GeoRegionId = 2, CountryId = 104, RegionId = 3, SchemeId = 2, SchmTypeId = 3, Cost = 6000 },
            new CostAnalysisItem { YearId = "2017", GeoRegionId = 3, CountryId = 105, RegionId = 4, SchemeId = 3, SchmTypeId = 2, Cost = 8000 }
        };

        // Output the list items to the console
        Console.WriteLine("List of CostAnalysisItems:");
        foreach (var item in items)
        {
            Console.WriteLine($"YearId: {item.YearId}, CountryId: {item.CountryId}, Cost: {item.Cost}");
        }

        // Path to your JSON file
        string filePath = @"C:\Users\HP\source\repos\Lorax C# CostAnalysis\Lorax C# CostAnalysis\data.json"; 

        // Deserialize the JSON data into a list of CostAnalysisItem objects
        var jsonContent = File.ReadAllText(filePath);  // Read the JSON file
        List<CostAnalysisItem> fileItems = JsonConvert.DeserializeObject<List<CostAnalysisItem>>(jsonContent); // Deserialize

        // Output the deserialized list from the file
        Console.WriteLine("\nList of CostAnalysisItems from JSON file:");
        foreach (var item in fileItems)
        {
            Console.WriteLine($"YearId: {item.YearId}, CountryId: {item.CountryId}, Cost: {item.Cost}");
        }

        // Step 3: Assertions
        // Assert the number of items in the list
        Assert.AreEqual(5, items.Count, "The item count in the list should be 5.");

        // Step 4: LINQ operations
        // Get the top item ordered by Cost in descending order and assert the CountryId
        var topItemByCost = items.OrderByDescending(i => i.Cost).FirstOrDefault();
        Assert.AreEqual(103, topItemByCost?.CountryId, "The top item by Cost should have CountryId 103.");

        // Sum Cost for the year 2016 and assert the total
        double totalCost2016 = items.Where(i => i.YearId == "2016").Sum(i => i.Cost);
        Assert.AreEqual(18000, totalCost2016, "The total Cost for 2016 should be 18000.");

        // Console output for visual confirmation
        Console.WriteLine("All assertions passed successfully.");
        Console.ReadLine(); // Prevent immediate console close

        // Keep the console window open after output
        Console.ReadLine(); // Added to prevent immediate close
    }
}
