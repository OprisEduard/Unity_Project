using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for UI components

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject PauseMenuCanvas;
    public GameObject OptionsPanel; // Panel to display options
    public Text OptionsText; // Text to display custom options message
    public AudioClip hoverSound; // Sound for button hover
    private AudioSource audioSource;
    private BackgroundMusic backgroundMusic; // Reference to the BackgroundMusic script

    void Start()
    {
        PauseMenuCanvas.SetActive(false); // Hide the pause menu
        if (OptionsPanel != null) OptionsPanel.SetActive(false); // Hide the options panel
        Time.timeScale = 1f; // Set time scale to normal
        paused = false; // Ensure paused state is false

        // Add AudioSource component if not present
        if (GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioSource.playOnAwake = false; // Ensure the sound doesn’t play automatically

        // Find BackgroundMusic in the scene
        backgroundMusic = UnityEngine.Object.FindFirstObjectByType<BackgroundMusic>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
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
        PauseMenuCanvas.SetActive(true);
        if (OptionsPanel != null) OptionsPanel.SetActive(false); // Hide options panel if open
        Time.timeScale = 0f;
        paused = true;

        // Stop background music if available
        if (backgroundMusic != null)
        {
            backgroundMusic.StopBackgroundMusic();
        }

        // Unlock the cursor
        MouseCursorManager.Instance.UnlockCursor();
    }

    public void Resume()
    {
        PauseMenuCanvas.SetActive(false);
        if (OptionsPanel != null) OptionsPanel.SetActive(false); // Ensure options panel is hidden
        Time.timeScale = 1f;
        paused = false;

        // Resume background music if available
        if (backgroundMusic != null)
        {
            backgroundMusic.ResumeBackgroundMusic();
        }

        // Lock the cursor
        MouseCursorManager.Instance.LockCursor();
    }

    public void MainMenuButton()
    {
        // Ensure the cursor is unlocked in the main menu
        MouseCursorManager.Instance.UnlockCursor();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

   /* public void ShowOptions()
    {
        UnityEngine.Debug.Log("ShowOptions triggered!"); // Debug log for troubleshooting

        if (OptionsPanel != null)
        {
            OptionsPanel.SetActive(true); // Show the options panel
            UnityEngine.Debug.Log("OptionsPanel activated.");
        }
        else
        {
            UnityEngine.Debug.LogWarning("OptionsPanel is not assigned in the Inspector!");
        }

        if (OptionsText != null)
        {
            OptionsText.text = "This is the options menu! Customize your settings here."; // Set your custom text
            UnityEngine.Debug.Log("OptionsText updated.");
        }
        else
        {
            UnityEngine.Debug.LogWarning("OptionsText is not assigned in the Inspector!");
        }
    }
   */
    public void PlayHoverSound()
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }
}
