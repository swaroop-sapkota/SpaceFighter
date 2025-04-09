using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        // Show the pause menu
        pauseMenu.SetActive(true);
        // Pause the game
        Time.timeScale = 0;
        // Unlock and show the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Home()
    {
        // Load the Main Menu
        SceneManager.LoadScene("Main Menu");
        // Unpause the game
        Time.timeScale = 1;
    }

    public void Resume()
    {
        // Hide the pause menu
        pauseMenu.SetActive(false);
        // Resume the game
        Time.timeScale = 1;
        // Lock and hide the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Restart()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Unpause the game
        Time.timeScale = 1;
    }
}
