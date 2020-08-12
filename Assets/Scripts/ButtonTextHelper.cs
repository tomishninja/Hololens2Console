using TMPro;
using UnityEngine;

public class ButtonTextHelper : MonoBehaviour
{
    /// <summary>
    /// Dots that will appear after some text has been truncated
    /// </summary>
    public const string trucatedDots = "...";

    /// <summary>
    /// 
    /// </summary>
    public ScrollableContentManager manager;

    /// <summary>
    /// The script that will display the text
    /// </summary>
    public TextMeshPro text;

    /// <summary>
    /// Tells the system were it can find the index 
    /// for the message contained within this button.
    /// </summary>
    public int index = -1;

    public void SetText(string newText)
    {
        // the button isn't that large so try not to fill it all up
        // or else just fill up the whole button
        if (newText.Length > 128)
        {
            text.SetText(newText.Substring(0, 128) + trucatedDots);
        }
        else
        {
            text.SetText(newText);
        }
    }

    public void ButtonPressed()
    {
        manager.DisplayFullMessage(index);
    }
}
