using UnityEngine;

// modify chaos trigger
// roll chaos die with every destiny check
// if chaos die >= destiny, trigger scene modification based on chaos roll

// reorganize chaos chart to go positivie-small-disruption to positive-bigger to negative-minor to negative-big
// 4-5 transmutation
// 6-7 illusion
// 8-9 conjuration
// 10-11 evocation
// 12-13 divination+
// 14-15 enchantment
// 16-17 abjuration
// 18-19 necromancy
// 20 divination-

public static class BentoDestiny
{
    private static int[] ChaosDie = { 4, 4, 6, 6, 8, 8, 10, 12, 20 };

    public static int GetChaosDie(int chaosLevel)
    {
        if (chaosLevel <= 1)
            return 4;

        if (chaosLevel >= 9)
            return 20;

        return ChaosDie[chaosLevel - 1];
    }

    public static bool GetChance(int chaosLevel)
    {
        // roll chaos die and d20
        // if d20 is < 4, return false (even if an event is triggered, the event is a non-event)
        // if d20 is <= chaos die, return true - something happens!
        // otherwise return false - proceed as normal
        int chaosRoll = Utilities.Roll(GetChaosDie(chaosLevel));
        int destinyRoll = Utilities.Roll(20);

        if (destinyRoll < 4 ||  destinyRoll > chaosRoll)
            return false;

        return true;
    }
}
