using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; // The background music clip
    private AudioSource audioSource; // AudioSource component

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
        }

        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause(); // Use Pause instead of Stop to allow resuming
        }
    }

    public void ResumeBackgroundMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.UnPause(); // Resume playback
        }
    }
}
