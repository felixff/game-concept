using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    void Start()
    {
        // Assign the buttons from the UI Document or query them directly
        var root = GetComponent<UIDocument>().rootVisualElement;

        playButton = root.Q<Button>("PlayButton"); // Replace "PlayButton" with your button's name
        exitButton = root.Q<Button>("ExitButton"); // Replace "ExitButton" with your button's name

        // Add click event listeners
        playButton.clicked += OnPlayClicked;
        exitButton.clicked += OnExitClicked;
    }

    private void OnPlayClicked()
    {
        // Load your game scene here
        SceneManager.LoadScene("Level"); // Replace "GameScene" with your actual scene name
    }

    private void OnExitClicked()
    {
        // Quit the game
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
