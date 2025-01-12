using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TextHoverColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI text;
    private Color originalColor;
    public Color hoverColor = Color.red; // The color when hovered

    public AudioClip hoverSound; // The audio clip to play on hover
    private AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Get the TextMeshProUGUI component
        text = GetComponent<TextMeshProUGUI>();

        // Store the original color
        originalColor = text.color;

        // Add an AudioSource component if one isn't already attached
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Prevent playing the sound automatically
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Change to hover color
        text.color = hoverColor;

        // Play the hover sound
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revert to original color
        text.color = originalColor;
    }
}
