using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Complete : MonoBehaviour
{
    public GameObject GetKeyObj_Txt;
    public GameObject UseMaterial_Txt;
    public GameObject RunSpaceship_Txt;

    private bool unlockedNewLevel = false;

    void Start()
    {
        // Reset material flags and UI texts
        GetKeyObj_Txt.SetActive(false);
        UseMaterial_Txt.SetActive(false);
        RunSpaceship_Txt.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the key collection text if materials haven't been found
            if (!(GetKeyObjectiveLevel2.material1Found && GetKeyObjectiveLevel2.material2Found && GetKeyObjectiveLevel2.material3Found && GetKeyObjectiveLevel2.material4Found))
            {
                GetKeyObj_Txt.SetActive(true);
            }
            else if (GetKeyObjectiveLevel2.material1Found && GetKeyObjectiveLevel2.material2Found && GetKeyObjectiveLevel2.material3Found && GetKeyObjectiveLevel2.material4Found && !unlockedNewLevel)
            {
                // Check if all materials are found and the player has killed enough enemies
                if (EnemyKillTracker.HasKilledEnough())
                {
                    // Show the Use Material prompt
                    UseMaterial_Txt.SetActive(true);

                    // Only show the RunSpaceship_Txt when both conditions are true
                    if (!RunSpaceship_Txt.activeSelf)
                    {
                        RunSpaceship_Txt.SetActive(true);
                    }

                    // Handle the level transition when 'E' is pressed
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // Hide texts and trigger level change
                        RunSpaceship_Txt.SetActive(false);
                        GetKeyObj_Txt.SetActive(false);
                        UseMaterial_Txt.SetActive(false);
                        unlockedNewLevel = true;

                        UnlockNewLevel();
                        SceneController.instance.NextLevel();
                    }
                }
                else
                {
                    // If enough enemies haven't been killed, hide the "Use Material" text
                    UseMaterial_Txt.SetActive(false);
                    // Optionally, you could add a hint like "Kill more enemies to activate" here
                }
            }
        }
    }

    void UnlockNewLevel()
    {
        // Get the current active scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // If the current scene index is greater than or equal to the reached index, update the reached index and unlocked level
        if (currentSceneIndex >= PlayerPrefs.GetInt("ReachedIndex", 0))
        {
            // Set the next level as the reached index
            PlayerPrefs.SetInt("ReachedIndex", currentSceneIndex + 1);

            // Increment the unlocked level count
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);

            // Save PlayerPrefs to persist across sessions
            PlayerPrefs.Save();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the texts when the player exits the trigger zone
            GetKeyObj_Txt.SetActive(false);
            UseMaterial_Txt.SetActive(false);
            RunSpaceship_Txt.SetActive(false);
        }
    }
}
