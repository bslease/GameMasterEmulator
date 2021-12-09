using UnityEngine;

public static class UNE
{
    static string[] NPC_MODIFIER = { "superfluous", "addicted", "conformist" };
    static string[] NPC_BEARING_A = { "scheming", "insane", "friendly", "hostile", "inquisitive", "knowing", "mysterious", "prejudiced" };
    static string[] NPC_NOUN = { "gypsy", "witch", "merchant" };
    static string[] NPC_POWERLEVEL = { "much less", "less", "neither more nor less", "more", "much more" };
    static string[] NPC_MOOD = {"unusually withdrawn", "unusually guarded", "unusually cautious", "true to form",
        "unusually sociable", "unusually helpful", "unusually forthcoming" };
    static string[,] NPC_BEARING_B =
    {
        // scheming
        { "intent", "bargain", "means" },
        // insane
        { "madness", "fear", "accident" },
        // friendly
        { "alliance", "comfort", "gratitiude" },
        // hostile
        { "death", "capture", "judgment" },
        // inquisitive
        { "questions", "investigation", "interest" },
        // knowing
        { "report", "effects", "examination" },
        // mysterious
        { "rumor", "uncertainty", "secrets" },
        // prejudiced
        { "reputation", "doubt", "bias" }
    };
    static string[] NPC_FOCUS = { "current scene", "parents", "wealth" };
    static string[] NPC_MOTIVE_VERB = { "advise", "obtain", "attempt" };
    static string[] NPC_MOTIVE_NOUN = { "wealth", "hardship", "affluence" };

    // UNE uses a chaos factor that it calls an R-Level to adjust certain probabilities
    // we're going to call it chaosFactor for clarity
    public static string GetNPC(int chaosFactor)
    {
        int bearingAIndex = Random.Range(0, NPC_BEARING_A.Length);
        string bearingA = NPC_BEARING_A[bearingAIndex];
        string modifier = NPC_MODIFIER[Random.Range(0, NPC_MODIFIER.Length)];
        string noun = NPC_NOUN[Random.Range(0, NPC_NOUN.Length)];
        string identity = "A " + bearingA + " and " + modifier + " " + noun + "\n";

        string mood = NPC_MOOD[Random.Range(0, NPC_MOOD.Length)];
        string behavior = "is behaving " + mood + " today.\n";

        string bearingB = NPC_BEARING_B[bearingAIndex, Random.Range(0, 2)]; // don't like this. use string[][] instead?
        string focus = NPC_FOCUS[Random.Range(0, NPC_FOCUS.Length)];
        string interest = "When approached they speak of\n" + bearingB + " regarding your " + focus + ".\n";

        string motiveVerb = NPC_MOTIVE_VERB[Random.Range(0, NPC_MOTIVE_VERB.Length)];
        string motiveNoun = NPC_MOTIVE_NOUN[Random.Range(0, NPC_MOTIVE_NOUN.Length)];
        string motive = "They aim to " + motiveVerb + " " + motiveNoun + ".\n";

        string powerLevel = NPC_POWERLEVEL[Random.Range(0, NPC_POWERLEVEL.Length)];
        string strength = "They seem " + powerLevel + " powerful than you.";

        return identity + behavior + interest + motive + strength;
    }
}
