using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public GameObject[] enemies;
    public GameObject[] uiElementsToHide; // assign your UI like health bars, mission text etc
    public GameObject gameCompletePanel; // assign your 'Game Completed' UI
    public GameObject gameOverPanel;
    public VideoPlayer endVideoPlayer;

    private bool gameFinished = false;

    private void Awake()
    {
        instance = this;
    }

    public void CompleteGame()
    {
        // Stop Player
        if (player != null)
        {
            //player.GetComponent<PlayerMovement>().enabled = false; // replace with your player movement script
            //player.GetComponent<PlayerShooting>().enabled = false; // if shooting
        }

        // Stop Enemies
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.SetActive(false);
            }
        }

        // Hide UIs
        foreach (GameObject ui in uiElementsToHide)
        {
            ui.SetActive(false);
        }

        // Play Ending Video
        if (endVideoPlayer != null)
        {
            endVideoPlayer.Play();
            endVideoPlayer.loopPointReached += EndVideoFinished; // Subscribe when video ends
        }

        gameFinished = true;
    }

    private void EndVideoFinished(VideoPlayer vp)
    {
        gameCompletePanel.SetActive(true); // Show "You completed the game"
    }

    private void Update()
    {
        if (gameFinished && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level 1"); // Restart level
        }
        else if (gameFinished && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // Quit game
        }
    }
}
