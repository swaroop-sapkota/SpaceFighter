using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            UnlockNewLevel();
            SceneController.instance.NextLevel();
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
}
