using UnityEngine;
using TMPro;

public class MissionProgressUI : MonoBehaviour
{
    public TextMeshProUGUI missionText; // Link the UI Text here
    public GameObject RunSpaceship_Txt;


    private void Update()
    {
        string material1Status = GetKeyObjective.material1Found ? "Done" : "Not Done";
        string material2Status = GetKeyObjective.material2Found ? "Done" : "Not Done";
        string material3Status = GetKeyObjective.material3Found ? "Done" : "Not Done";

        int kills = EnemyKillTracker.dragonKillCount;
        int killsNeeded = EnemyKillTracker.requiredDragonKills;

        missionText.text = "Mission Progress:\n" +
                           "Material 1: " + material1Status + "\n" +
                           "Material 2: " + material2Status + "\n" +
                           "Material 3: " + material3Status + "\n" +
                           "Dragons Killed: " + kills + "/" + killsNeeded;

        // Optional: Hide the mission text once everything is completed
        if (GetKeyObjective.material1Found &&
            GetKeyObjective.material2Found &&
            GetKeyObjective.material3Found &&
            EnemyKillTracker.HasKilledEnough())
        {
            missionText.enabled = false; // Hide the text
            RunSpaceship_Txt.SetActive(true);
        }
    }
}
