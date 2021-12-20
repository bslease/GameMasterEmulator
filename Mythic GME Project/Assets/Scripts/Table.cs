using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Table
{
    // type
    // title
    // category / tags
    // result row:
    // low value inclusive, high value inclusive, result
    // format string
    // array/list of results

    // types
    // supporting: no user-side roll
    // primary: a table a user can roll on that doesn't reference any other tables
    // meta: a table of tables - the other tables can be of any type

    // images? (cards)

    public string file;

    public void ReadFileAtLocation()
    {
        //This resets the file string just in case read.ReadToEnd() does not overwrite it. 
        file = "";

        if (File.Exists(GetPath()))
        {
            FileStream fileStream = new FileStream(GetPath(), FileMode.Open, FileAccess.ReadWrite);
            StreamReader read = new StreamReader(fileStream);
            file = read.ReadToEnd();
        }
        else
        {
            Debug.LogError("File at " + GetPath() + " does not exist");
        }
    }

    public struct Row
    {
        public int low;
        public int high;
        public string result;
    }

    public string Title;
    public List<Row> Rows = new List<Row>();

    private string GetPath()
    {
        return Application.dataPath + "/CSV/" + "testfile.csv";
    }

    public void LoadTable()
    {
        string title = "";
        ReadFileAtLocation();
        string[] lines = file.Split("\n"[0]);

        string[] titleParts = lines[0].Split(","[0]);
        title = titleParts[0];

        Debug.Log(title);

        string[] rowParts = lines[1].Split(","[0]);
        int low;
        int high;
        int.TryParse(rowParts[0], out low);
        int.TryParse(rowParts[1], out high);
        string result = rowParts[2];

        Debug.Log(low + "-" + high + ":" + result);
    }

}
