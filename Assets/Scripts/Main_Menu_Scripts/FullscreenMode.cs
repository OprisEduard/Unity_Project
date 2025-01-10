using UnityEngine;

public class FullscreenMode : MonoBehaviour
{
    void Start()
    {
        // Set the game to start in fullscreen
        UnityEngine.Debug.Log("FullscreenMode script is running.");
        Screen.fullScreen = true;
    }
}
