using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    private GameObject pauseMenuInstance;
    private UIDocument pauseMenuDocument;
    private bool isPaused = false;

    private void Awake()
    {
        CreatePauseMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void OnEnable()
    {
        if (pauseMenuDocument.rootVisualElement is VisualElement)
        {
            SetupMenu();
        }
    }

    private void CreatePauseMenu()
    {
        pauseMenuInstance = Instantiate(pauseMenuPrefab);
        pauseMenuDocument = pauseMenuInstance.GetComponent<UIDocument>();
        pauseMenuInstance.SetActive(false);  // Start with the menu disabled
    }

    private void SetupMenu()
    {
        VisualElement root = pauseMenuDocument.rootVisualElement;

        Button resumeButton = root.Q<Button>("ResumeButton");
        Button quitButton = root.Q<Button>("QuitButton");

        resumeButton.clicked += ResumeGame;
        quitButton.clicked += QuitGame;
    }

    private void TogglePause()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        if (!pauseMenuInstance.activeSelf)
        {
            pauseMenuInstance.SetActive(true);
            SetupMenu();
        }
        Time.timeScale = 0;  // Pause the game
        isPaused = true;
    }

    private void ResumeGame()
    {
        if (pauseMenuInstance.activeSelf)
        {
            pauseMenuInstance.SetActive(false);
        }
        Time.timeScale = 1;  // Resume the game
        isPaused = false;
    }


    private void QuitGame()
    {
        Time.timeScale = 1;  // Ensure the game isn't paused when quitting
        SceneManager.LoadScene("MainMenu");  // Load main menu scene
    }
}
