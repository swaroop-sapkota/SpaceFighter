using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUi.SetActive(false); // Make sure pause menu is hidden at the start
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the pause menu is active or not
        if (pauseMenuUi.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Toggle pause menu with Escape key
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenuUi.activeInHierarchy)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        // Disable game movement and time flow (pause game)
        Time.timeScale = 0f;
        pauseMenuUi.SetActive(true);
        Debug.Log("Game Paused");
    }

    public void Resume()
    {
        // Enable game movement and time flow (resume game)
        Time.timeScale = 1f;
        pauseMenuUi.SetActive(false);
        Debug.Log("Game Resumed");
    }

    public void mainMenu()
    {
        // Unpause and load the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Main Menu");
    }

    public void restart()
    {
        // Unpause and restart the current level
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}



//using Unity.VisualScripting;
//using UnityEngine;

//public class PauseMenu : MonoBehaviour
//{
//    public static bool GameIsPaused = false;
//    public GameObject pauseMenuUI;

//    // Update is called once per frame
//    void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.P))
//        {
//            if (GameIsPaused)
//            {
//                Resume();
//            }
//            else
//            {
//                Pause(); 
//            }
//        }
//    }

//    public void Resume()
//    {
//        pauseMenuUI.SetActive(false);
//        Time.timeScale = 1f;
//        GameIsPaused = false;
//    }

//    void Pause()
//    { 
//        pauseMenuUI.SetActive(true);
//        Time.timeScale = 0f;
//        GameIsPaused = true;
//    }

//    public void LoadMenu()
//    {
//        Debug.Log("Loading Menu");
//    }

//    public void QuitGame()
//    {
//        Debug.Log("Quitting Game");
//    }
//}
