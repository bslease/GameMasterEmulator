//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using System.IO;

public class Resource
{
    public string Name;
    public string Type;
    public string Location;
    public float Version;
    public string Source;

    protected string RawFile;

    public override string ToString()
    {
        string result = Name;
        result += "," + Type;
        result += "," + Location;
        result += "," + Version;
        result += "," + Source;

        return result;
    }

    public void LoadResource()
    {
        RawFile = Utilities.ReadFile(Application.dataPath + "/CSV/" + Location);
        Debug.Log(RawFile);
    }

    public virtual void ParseRawFile()
    {
        Debug.Log("Attempt to parse unkonwn resource type");
    }
}
