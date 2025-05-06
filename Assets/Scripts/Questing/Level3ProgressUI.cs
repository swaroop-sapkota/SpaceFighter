using UnityEngine;
using TMPro;

public class Level3ProgressUI : MonoBehaviour
{
    public TextMeshProUGUI missionText;
    public GameObject RunSpaceship_Txt;

    private void Update()
    {
        string material1Status = GetKeyObjectiveLevel3.material1Found ? "Done" : "Not Done";
        string material2Status = GetKeyObjectiveLevel3.material2Found ? "Done" : "Not Done";
        string material3Status = GetKeyObjectiveLevel3.material3Found ? "Done" : "Not Done";
        string material4Status = GetKeyObjectiveLevel3.material4Found ? "Done" : "Not Done";
        string material5Status = GetKeyObjectiveLevel3.material5Found ? "Done" : "Not Done";

        int kills = EnemyKillTracker.dragonKillCount;
        int killsNeeded = EnemyKillTracker.requiredDragonKills;

        missionText.text = "Mission Progress:\n" +
                           "Material 1: " + material1Status + "\n" +
                           "Material 2: " + material2Status + "\n" +
                           "Material 3: " + material3Status + "\n" +
                           "Material 4: " + material4Status + "\n" +
                           "Material 5: " + material5Status + "\n" + 
                           "Dragons Killed: " + kills + "/" + killsNeeded;

        if (GetKeyObjectiveLevel3.material1Found &&
            GetKeyObjectiveLevel3.material2Found &&
            GetKeyObjectiveLevel3.material3Found &&
            GetKeyObjectiveLevel3.material4Found &&
            GetKeyObjectiveLevel3.material5Found && 
            EnemyKillTracker.HasKilledEnough())
        {
            missionText.enabled = false;
            RunSpaceship_Txt.SetActive(true);
        }
    }
}
