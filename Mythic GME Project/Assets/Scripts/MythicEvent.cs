using UnityEngine;

public static class MythicEvent
{
    private static string[] ActionsList =
    {
        "Attainment", "Starting", "Neglect", "Fight", "Recruit", "Triumph", "Violate", "Oppose", "Malice", "Communicate",
        "Persecute", "Increase", "Decrease", "Abandon", "Gratify", "Inquire", "Antagonise", "Move", "Waste", "Truce",
        "Release", "Befriend", "Judge", "Desert", "Dominate", "Procrastinate", "Praise", "Separate", "Take", "Break",
        "Heal", "Delay", "Stop", "Lie", "Return", "Immitate", "Struggle", "Inform", "Bestow", "Postpone",
        "Expose", "Haggle", "Imprison", "Release", "Celebrate", "Develop", "Travel", "Block", "Harm", "Debase",
        "Overindulge", "Adjourn", "Adversity", "Kill", "Disrupt", "Usurp", "Create", "Betray", "Agree", "Abuse",
        "Oppress", "Inspect", "Ambush", "Spy", "Attach", "Carry", "Open", "Carelessness", "Ruin", "Extravagance",
        "Trick", "Arrive", "Propose", "Divide", "Refuse", "Mistrust", "Deceive", "Cruelty", "Intolerance", "Trust",
        "Excitement", "Activity", "Assist", "Care", "Negligence", "Passion", "Work hard", "Control", "Attract", "Failure",
        "Pursue", "Vengeance", "Proceedings", "Dispute", "Punish", "Guide", "Transform", "Overthrow", "Oppress", "Change"
    };

    private static string[] SubjectsList =
    {
        "Goals", "Dreams", "Environment", "Outside", "Inside", "Reality", "Allies", "Enemies", "Evil", "Good",
        "Emotions", "Opposition", "War", "Peace", "The innocent", "Love", "The spiritual", "The intellectual", "New ideas", "Joy",
        "Messages", "Energy", "Balance", "Tension", "Friendship", "The physical", "A project", "Pleasures", "Pain", "Possessions",
        "Benefits", "Plans", "Lies", "Expectations", "Legal matters", "Bureaucracy", "Business", "A path", "News", "Exterior factors",
        "Advice", "A plot", "Competition", "Prison", "Illness", "Food", "Attention", "Success", "Failure", "Travel",
        "Jealousy", "Dispute", "Home", "Investment", "Suffering", "Wishes", "Tactics", "Stalemate", "Randomness", "Misfortune",
        "Death", "Disruption", "Power", "A burden", "Intrigues", "Fears", "Ambush", "Rumor", "Wounds", "Extravagance",
        "A representative", "Adversities", "Opulence", "Liberty", "Military", "The mundane", "Trials", "Masses", "Vehicle", "Art",
        "Victory", "Dispute", "Riches", "Status quo", "Technology", "Hope", "Magic", "Illusions", "Portals", "Danger",
        "Weapons", "Animals", "Weather", "Elements", "Nature", "The public", "Leadership", "Fame", "Anger", "Information"
    };

    private static string[] FocusList =
    {
        "Remote event", "NPC action", "Introduce a new NPC", "Move toward a thread", "Move away from a thread",
        "Close a thread", "PC negative", "PC positive", "Ambiguous event", "NPC negative", "NPC positive"
    };

    private static string GetRandomListItem(string[] list)
    {
        return list[Utilities.Roll(list.Length) - 1];
    }

    public static string GetEventAction()
    {
        return GetRandomListItem(ActionsList);
    }

    public static string GetEventSubject()
    {
        return GetRandomListItem(SubjectsList);
    }

    public static string GetEventFocus()
    {
        int d100 = Utilities.Roll(100);
        if (d100 <= 7) return FocusList[0];
        if (d100 >= 8 && d100 <= 28) return FocusList[1];
        if (d100 >= 29 && d100 <= 35) return FocusList[2];
        if (d100 >= 36 && d100 <= 45) return FocusList[3];
        if (d100 >= 46 && d100 <= 52) return FocusList[4];
        if (d100 >= 53 && d100 <= 55) return FocusList[5];
        if (d100 >= 56 && d100 <= 67) return FocusList[6];
        if (d100 >= 68 && d100 <= 75) return FocusList[7];
        if (d100 >= 76 && d100 <= 83) return FocusList[8];
        if (d100 >= 84 && d100 <= 92) return FocusList[9];
        return FocusList[10];
    }

    public static string GetRandomEvent()
    {
        string focus = GetEventFocus();
        string action = GetEventAction();
        string subject = GetEventSubject();

        string myEvent = focus + ": " + action + " (of) " + subject;
        return myEvent;
    }

}
