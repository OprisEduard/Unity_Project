using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TextHoverColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI text;
    private Color originalColor;
    public Color hoverColor = Color.red; // The color when hovered

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component
        originalColor = text.color;           // Store the original color
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = hoverColor; // Change to hover color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = originalColor; // Revert to original color
    }
}
