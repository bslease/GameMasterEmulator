using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Emulator : MonoBehaviour
{
    public TMP_Text ChaosText;
    public TMP_Text LikelihoodText;
    public TMP_Text ChancesText;
    public TMP_Text FateText;
    public TMP_Text RollText;

    private int StartingChaos = 5;
    private int MaxChaos = 9;
    private int MinChaos = 1;
    private int CurrentChaos;
    private int CurrentLikelihood = MythicFate.Odds.FiftyFifty;

    private float FadeRate = 0.1f;
    private float FadeAlphaMin = 0.4f;

    private void Awake()
    {
        CurrentChaos = StartingChaos;
        RefreshContextUI();
        FateText.text = "Welcome";
        FateText.alpha = 1.0f;
        RollText.text = "";
    }

    void RefreshContextUI()
    {
        ChaosText.text = "Chaos: " + CurrentChaos.ToString();
        LikelihoodText.text = "Likelihood: " + MythicFate.Odds.WordList[CurrentLikelihood];
        ChancesText.text = "Chance of yes: " + MythicFate.GetChances(CurrentChaos, CurrentLikelihood) + "%";
        RollText.text = "";
    }

    void DisplayFateText(string message)
    {
        FateText.text = message;
        FateText.alpha = 1.0f;
    }

    //int numRolls = 0;
    //int numChaosEvents = 0;
    //float chanceChaosEvent = 0.0f;
    //int bentoChaosLevel = 2;

    void Update()
    {
        //bool chaosEventTriggered = BentoDestiny.GetChance(bentoChaosLevel);
        //if (chaosEventTriggered)
        //    numChaosEvents++;
        //numRolls++;
        //chanceChaosEvent = (float)numChaosEvents / (float)numRolls;
        //RollText.text = "numEvents: " + numChaosEvents + "; numRolls: " + numRolls;
        //FateText.text = chanceChaosEvent.ToString();

        if (FateText.alpha > FadeAlphaMin)
        {
            FateText.alpha -= FadeRate * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CurrentChaos = Mathf.Min(++CurrentChaos, MaxChaos);
            RefreshContextUI();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CurrentChaos = Mathf.Max(--CurrentChaos, MinChaos);
            RefreshContextUI();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CurrentLikelihood = Mathf.Min(++CurrentLikelihood, MythicFate.Odds.HasToBe);
            RefreshContextUI();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CurrentLikelihood = Mathf.Max(--CurrentLikelihood, MythicFate.Odds.Impossible);
            RefreshContextUI();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            int d100 = Utilities.Roll(100);
            RollText.text = "you roll a d100: " + d100;
            DisplayFateText(MythicFate.AskFate(CurrentChaos, CurrentLikelihood, d100));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int changeSceneRoll = Utilities.Roll(10);
            RollText.text = "you roll a d10: " + changeSceneRoll;

            if (changeSceneRoll > CurrentChaos)
            {
                // roll > chaos means play scene as intended
                DisplayFateText("Proceed");
            }
            else if (changeSceneRoll % 2 == 0)
            {
                // even roll <= chaos results in interrupted scene
                DisplayFateText("Your plan is interrupted\n" + MythicEvent.GetRandomEvent());
            }
            else
            {
                // odd roll <= chaos results in altered scene
                DisplayFateText("Your plan is altered in some way");
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            // generate random event
            RollText.text = "";
            DisplayFateText(MythicEvent.GetRandomEvent());
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            // generate UNE npc
            RollText.text = "";
            DisplayFateText(UNE.GetNPC(CurrentChaos));
        }
    }
}
