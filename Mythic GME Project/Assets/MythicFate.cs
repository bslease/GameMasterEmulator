using UnityEngine;

public static class MythicFate
{
    // FateChart structure and usage:
    // columns are chaos factor, from 9 to 1 (e.g. chaos factor 9 is the first tuplet and therefore the zeroth index)
    // rows are likelihood, from impossible (0th index) to has-to-be (last index)
    // roll d100 (1=100) and compare to the relevant tuple based on likelihood and chaos: 
    //   roll <= 2nd tuple index = yes; roll <= 1st index = exceptional yes
    //   roll >  2nd tuple index =  no; roll >= 3rd index = exceptional no
    // e.g. if chaos is 5 and likelihood is 50/50, our tuple should be 10,50,91
    //   roll <= 50 = yes; roll <= 10 = exceptional yes
    //   roll >  50 =  no; roll >= 91 = exceptional no
    // TLDR: the higher your chaos factor, the more likely you are to get a yes or exceptional yes answer
    private const int exceptionalYesIndex = 0;
    private const int yesnoIndex = 1;
    private const int exceptionalNoIndex = 2;
    static int[,,] FateChart =
    {
        { {10, 50, 91}, { 5, 25, 86}, { 3, 15, 84}, { 2, 10, 83}, { 1, 5, 82}, { 1, 5, 82}, { 0, 0,81}, { 0, 0,81}, { 0,-20,77}  },
        { {15, 75, 96}, {10, 50, 91}, { 7, 35, 88}, { 5, 25, 86}, { 3,15, 84}, { 2,10, 83}, { 1, 5,82}, { 1, 5,82}, { 0,  0,81}  },
        { {16, 85, 97}, {13, 65, 94}, {10, 50, 91}, { 9, 45, 90}, { 5,25, 86}, { 3,15, 84}, { 2,10,83}, { 1, 5,82}, { 1,  5,82}  },
        { {18, 90, 99}, {15, 75, 96}, {11, 55, 92}, {10, 50, 91}, { 7,35, 88}, { 4,20, 85}, { 3,15,84}, { 2,10,83}, { 1,  5,82}  },
        { {19, 95,100}, {16, 85, 97}, {15, 75, 96}, {13, 65, 94}, {10,50, 91}, { 7,35, 88}, { 5,25,86}, { 3,15,84}, { 2, 10,83}  },
        { {19, 95,100}, {18, 90, 99}, {16, 85, 97}, {16, 80, 97}, {13,65, 94}, {10,50, 91}, { 9,45,90}, { 5,25,86}, { 4, 20,85}  },
        { {20,100,  0}, {19, 95,100}, {18, 90, 99}, {16, 85, 97}, {15,75, 96}, {11,55, 92}, {10,50,91}, { 7,35,88}, { 5, 25,86}  },
        { {21,105,  0}, {19, 95,100}, {19, 95,100}, {18, 90, 99}, {16,85, 97}, {15,75, 96}, {13,65,94}, {10,50,91}, { 9, 45,90}  },
        { {23,115,  0}, {20,100,  0}, {19, 95,100}, {19, 95,100}, {18,90, 99}, {16,80, 97}, {15,75,96}, {11,55,92}, {10, 50,91}  },
        { {25,125,  0}, {22,110,  0}, {19, 95,100}, {19, 95,100}, {18,90, 99}, {16,85, 97}, {16,80,97}, {13,65,94}, {11, 55,92}  },
        { {26,145,  0}, {26,130,  0}, {20,100,  0}, {20,100,  0}, {19,95,100}, {19,95,100}, {18,90,99}, {16,85,97}, {16, 80,97}  }
    };

    public class Odds
    {
        public static string[] WordList = { "Impossible", "No Way", "Very Unlikley", "Unlikely", "50/50",
            "Somewhat Likely", "Likely", "Very Likely", "Near Sure Thing", "Sure Thing", "Has To Be" };

        public const int Impossible = 0;
        public const int NoWay = 1;
        public const int VeryUnlikley = 2;
        public const int Unlikely = 3;
        public const int FiftyFifty = 4;
        public const int SomewhatLikely = 5;
        public const int Likely = 6;
        public const int VeryLikely = 7;
        public const int NearSureThing = 8;
        public const int SureThing = 9;
        public const int HasToBe = 10;
    }

    public static int GetChances(int chaos, int likelihood)
    {
        int chaosIndex = 9 - chaos;
        return FateChart[likelihood, chaosIndex, yesnoIndex];
    }

    public static string AskFate(int chaos, int likelihood, int d100)
    {
        string answer = "No";
        string triggered = "";

        // did we trigger a random event?
        if (d100 % 11 == 0 && d100 / 10 < chaos)
        {
            //Debug.Log("...random event triggered: " + MythicEvent.GetRandomEvent());
            triggered = "\n...Something happened...\n" + MythicEvent.GetRandomEvent();
        }

        // look up the answer
        int chaosIndex = 9 - chaos;
        if (d100 <= FateChart[likelihood, chaosIndex, yesnoIndex])
        {
            if (d100 <= FateChart[likelihood, chaosIndex, exceptionalYesIndex])
            {
                answer = "Exceptional Yes";
            }
            else
            {
                answer = "Yes";
            }
        }
        else if (d100 >= FateChart[likelihood, chaosIndex, exceptionalNoIndex])
        {
            answer = "Exceptional No";
        }

        return answer + triggered;
    }
}
