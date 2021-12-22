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

        string[] titleParts = lines[0].Split(","[0]);
        string title = titleParts[0];

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
