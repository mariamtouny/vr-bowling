using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuCanvas; // Reference to the menu canvas

    // Start a new game
    public void StartGame()
    {
        SceneManager.LoadScene("bowling"); // Load your actual game scene
        Time.timeScale = 1f; // Ensure game is not paused
    }

    // Quit the game (works in the built version)
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Load the main menu scene
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // In case the game is paused
        SceneManager.LoadScene("SampleScene"); // Replace with your main menu scene name
    }

    // Resume the game (unpause and hide menu)
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Unpause the game
        menuCanvas.SetActive(false); // Hide the menu canvas
    }
}
