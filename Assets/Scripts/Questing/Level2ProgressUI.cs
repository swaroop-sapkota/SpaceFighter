using UnityEngine;
using TMPro;

public class Level2ProgressUI : MonoBehaviour
{
    public TextMeshProUGUI missionText; // Link the UI Text here
    public GameObject RunSpaceship_Txt;


    private void Update()
    {
        string material1Status = GetKeyObjectiveLevel2.material1Found ? "Done" : "Not Done";
        string material2Status = GetKeyObjectiveLevel2.material2Found ? "Done" : "Not Done";
        string material3Status = GetKeyObjectiveLevel2.material3Found ? "Done" : "Not Done";
        string material4Status = GetKeyObjectiveLevel2.material4Found ? "Done" : "Not Done";

        int kills = EnemyKillTracker.dragonKillCount;
        int killsNeeded = EnemyKillTracker.requiredDragonKills;

        missionText.text = "Mission Progress:\n" +
                           "Material 1: " + material1Status + "\n" +
                           "Material 2: " + material2Status + "\n" +
                           "Material 3: " + material3Status + "\n" +
                           "Material 4: " + material4Status + "\n" +
                           "Dragons Killed: " + kills + "/" + killsNeeded;

        // Optional: Hide the mission text once everything is completed
        if (GetKeyObjectiveLevel2.material1Found &&
            GetKeyObjectiveLevel2.material2Found &&
            GetKeyObjectiveLevel2.material3Found &&
            GetKeyObjectiveLevel2.material4Found &&
            EnemyKillTracker.HasKilledEnough())
        {
            missionText.enabled = false; // Hide the text
            RunSpaceship_Txt.SetActive(true);

        }
    }
}
