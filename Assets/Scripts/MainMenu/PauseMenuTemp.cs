using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;  // We need this for UI interaction detection

public class PauseMenuReal : MonoBehaviour
{
    public GameObject pauseMenu;  // Reference to the pause menu UI
    public static bool isPaused = false;  // Track whether the game is paused

    void Start()
    {
        pauseMenu.SetActive(false);  // Initially hide the pause menu
    }

    void Update()
    {
        // Toggle pause when pressing the 'P' key (or when clicking the mouse)
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Function to pause the game
    public void PauseGame()
    {
        // Show the pause menu
        pauseMenu.SetActive(true);

        // Freeze the game time (pause gameplay)
        Time.timeScale = 0;

        // Make the cursor visible and free (unclicked)
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Mark the game as paused
        isPaused = true;

        // Optionally set focus to the first UI button in the menu (helps with navigation)
        EventSystem.current.SetSelectedGameObject(pauseMenu.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
    }

    // Function to resume the game
    public void ResumeGame()
    {
        // Hide the pause menu
        pauseMenu.SetActive(false);

        // Unfreeze the game time (resume gameplay)
        Time.timeScale = 1;

        // Hide the cursor and lock it to the center
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Mark the game as not paused
        isPaused = false;
    }

    // Function to go to the main menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1;  // Make sure the game is not paused when loading the main menu
        SceneManager.LoadScene("Main Menu");  // Load the Main Menu scene
    }

    // Function to restart the game
    public void Restart()
    {
        // Reload the current scene (restart the level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Unpause the game
        Time.timeScale = 1;
    }
}

//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PauseMenuReal : MonoBehaviour
//{


//    public GameObject pauseMenu;
//    public static bool isPaused;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        pauseMenu.SetActive(false);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.P) || (isPaused && Input.GetMouseButtonDown(0)))
//        {
//            if (isPaused)
//            {
//                ResumeGame();
//            }
//            else
//            {
//                PauseGame();
//            }
//        }
//    }

//    public void PauseGame()
//    {
//        //pauseMenu.SetActive(true);
//        //Time.timeScale = 0f;
//        //isPaused = true;

//        pauseMenu.SetActive(true);
//        Time.timeScale = 0;
//        Cursor.visible = true;
//        Cursor.lockState = CursorLockMode.None;
//        isPaused = true;
//    }

//    public void ResumeGame()
//    {
//        pauseMenu.SetActive(false);
//        Time.timeScale = 1f;
//        Cursor.visible = false;
//        Cursor.lockState = CursorLockMode.Locked;
//        isPaused = false;
//    }

//    public void GoToMainMenu()
//    {
//        Time.timeScale = 1f;
//        SceneManager.LoadScene("Main Menu");
//    }


//    public void Restart()
//    {
//        // Reload the current scene
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//        // Unpause the game
//        Time.timeScale = 1;
//    }
//}


