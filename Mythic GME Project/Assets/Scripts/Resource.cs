//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

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
        //Debug.Log(RawFile);
    }

    public virtual void ParseRawFile()
    {
        Debug.Log("Attempt to parse unknown resource type");
    }

    public virtual void ParseRawFileData(string rawFileData)
    {
        Debug.Log("Attempt to parse unknown resource type");
    }
}
