//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Utilities
{
    public static List<string> ResourceTypes = new List<string>() { "table" };
    public static List<string> ResourceFileTypes = new List<string>() { ".csv" };
    public static List<string> FileExclusionList = new List<string>() {
        "_manifest.csv", "testfile.csv", "weather_precipitation.csv", "weather_temp.csv", "weather_wind.csv"
    };

    public static int Roll(int die)
    {
        return Random.Range(1, die+1);
    }

    public static List<string> FindAllResourcesInDirectory()
    {
        List<string> resourceList = new List<string>();
        IEnumerable<string> filePaths = Directory.EnumerateFiles(Application.dataPath + "/CSV/");
        foreach (string filePath in filePaths)
        {
            var fileInfo = new FileInfo(filePath); 
            if (ResourceFileTypes.Contains(fileInfo.Extension.ToLower()) && !FileExclusionList.Contains(fileInfo.Name.ToLower()))
            {
                resourceList.Add(filePath);
                //Debug.Log(filePath);
            }
        }
        return resourceList;
    }

    public static string ReadFile(string location)
    {
        //location = Application.dataPath + "/CSV/" + "testfile.csv";
        //This resets the file string just in case read.ReadToEnd() does not overwrite it. 
        string file = "";

        if (File.Exists(location))
        {
            FileStream fileStream = new FileStream(location, FileMode.Open, FileAccess.ReadWrite);
            StreamReader read = new StreamReader(fileStream);
            file = read.ReadToEnd();
        }
        else
        {
            Debug.LogError("File at " + location + " does not exist");
        }

        return file;
    }
}
