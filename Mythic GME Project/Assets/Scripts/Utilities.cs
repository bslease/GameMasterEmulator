//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using UnityEngine.UI;

public static class Utilities
{
    public const string TABLESPATH = "C:/Users/bslea/Downloads/DnD/data/tables/";
    public const string IMAGESPATH = "C:/Users/bslea/Downloads/DnD/data/images/";

    public static List<string> ResourceTypes = new List<string>() { "table" };
    public static List<string> ResourceFileTypes = new List<string>() { ".csv" };
    public static List<string> FileExclusionList = new List<string>() {
        // "_manifest.csv", "testfile.csv", "weather_precipitation.csv", "weather_temp.csv", "weather_wind.csv"
    };

    public static int Roll(int die)
    {
        return Random.Range(1, die+1);
    }

    public static Texture2D LoadPNG(string filePath)
    {
        //// read image and store in a byte array
        //byte[] byteArray = File.ReadAllBytes(@"D:\SampleImage.png");
        ////create a texture and load byte array to it
        //// Texture size does not matter 
        //Texture2D sampleTexture = new Texture2D(2, 2);
        //// the size of the texture will be replaced by image size
        //bool isLoaded = sampleTexture.LoadImage(byteArray);
        //// apply this texure as per requirement on image or material
        //GameObject image = GameObject.Find("RawImage");
        //if (isLoaded)
        //{
        //    image.GetComponent<RawImage>().texture = sampleTexture;
        //}


        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

    public static List<string> FindAllResourcesInDirectory()
    {
        List<string> resourceList = new List<string>();
        //IEnumerable<string> filePaths = Directory.EnumerateFiles(Application.dataPath + "/CSV/");
        IEnumerable<string> filePaths = Directory.EnumerateFiles(TABLESPATH);
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
