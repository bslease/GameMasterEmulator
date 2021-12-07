using UnityEngine;

public static class Utilities
{
    public static int Roll(int die)
    {
        return Random.Range(1, die+1);
    }
}
