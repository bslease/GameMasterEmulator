using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Table : Resource
{
    public struct Row
    {
        public int low;
        public int high;
        public string result;
    }

    public string Title;
    public List<Row> Rows = new List<Row>();
    int MaxRoll;
    int StartingLineIndex;

    public string RollOnTable()
    {
        string result = "error: result unknown";
        int dieRoll = Utilities.Roll(MaxRoll);
        foreach (Row r in Rows)
        {
            if (dieRoll >= r.low && dieRoll <= r.high)
            {
                result = r.result;
                break;
            }
        }
        return result;
    }

    public override void ParseRawFile()
    {
        string[] lines = RawFile.Split("\n"[0]);

        for (int i=StartingLineIndex; i<lines.Length; i++)
        {
            if (lines[i] == string.Empty)
                continue;

            string[] values = lines[i].Split(","[0]);
            if (values.Length < 3)
                continue;

            if (Utilities.ResourceTypes.Contains(values[0]))
            {
                break;
            }

            int low;
            int high;
            int.TryParse(values[0], out low);
            int.TryParse(values[1], out high);
            string result = values[2];

            Row row = new Row();
            row.low = low;
            row.high = high;
            row.result = result;
            Rows.Add(row);

            if (high > MaxRoll)
            {
                MaxRoll = high;
            }
        }

        //Debug.Log(this.ToString());
    }

    public override void ParseRawFileData(string rawFileData, int startingLineIndex)
    {
        RawFile = rawFileData;
        StartingLineIndex = startingLineIndex;
        ParseRawFile();
    }

    public override string ToString()
    {
        string result = base.ToString();
        for (int i=0; i<Rows.Count; i++)
        {
            result += "\n" + Rows[i].low + "-" + Rows[i].high + ": " + Rows[i].result;
        }
        return result;
    }
}
