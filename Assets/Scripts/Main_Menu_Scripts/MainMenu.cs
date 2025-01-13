using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class MainMenu : MonoBehaviour
{
    public AudioClip playClickSound; // Sound for the Play button
    public AudioClip quitClickSound; // Sound for the Quit button
    private AudioSource audioSource; // AudioSource component

    void Start()
    {
        // Ensure the cursor is visible in the main menu
        MouseCursorManager.Instance.UnlockCursor();

        // Add an AudioSource component if one doesn't already exist
        if (GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioSource.playOnAwake = false; // Prevent the sound from playing automatically
    }

    // Load Scene
    public void Play()
    {
        // Play the Play button click sound
        PlaySound(playClickSound);

        // Lock the cursor when starting the game
        MouseCursorManager.Instance.LockCursor();

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit Game
    public void Quit()
    {
        // Play the Quit button click sound
        PlaySound(quitClickSound);

#if UNITY_EDITOR
        // Stop Play Mode in Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application in a built game
        UnityEngine.Application.Quit();
#endif
    }

    // Generic method to play a sound
    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
