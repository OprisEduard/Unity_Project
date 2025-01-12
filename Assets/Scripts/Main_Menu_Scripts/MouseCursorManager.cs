using UnityEngine;

public class MouseCursorManager : MonoBehaviour
{
    public static MouseCursorManager Instance { get; private set; }

    void Awake()
    {
        // Ensure only one instance of the MouseCursorManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
        Cursor.visible = false;                  // Hides the cursor
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;  // Unlocks the cursor
        Cursor.visible = true;                   // Makes the cursor visible
    }
}
