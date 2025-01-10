using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load Scene
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit Game
    public void Quit()
    {
#if UNITY_EDITOR
        // Stop Play Mode in Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application in a built game
        UnityEngine.Application.Quit();
#endif
    }
}
