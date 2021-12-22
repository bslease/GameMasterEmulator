using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Table : Resource
{
    // source
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

    //public string file;

    public struct Row
    {
        public int low;
        public int high;
        public string result;
    }

    public string Title;
    public List<Row> Rows = new List<Row>();

    public override void ParseRawFile()
    {
        string[] lines = RawFile.Split("\n"[0]);

        for (int i=0; i<lines.Length; i++)
        {
            if (lines[i] == string.Empty)
                continue;

            string[] values = lines[i].Split(","[0]);
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
        }

        //Debug.Log(this.ToString());
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
