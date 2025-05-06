using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        // Ensure only one instance of SceneController exists
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);  // Loads the next scene based on the build index
        }
        else
        {
            Debug.Log("No more levels to load.");
            // Optionally, show a completion screen or restart the game here
        }
    }
}
