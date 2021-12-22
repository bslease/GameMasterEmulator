using UnityEngine;
using System.IO;

public static class Utilities
{
    public static int Roll(int die)
    {
        return Random.Range(1, die+1);
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
