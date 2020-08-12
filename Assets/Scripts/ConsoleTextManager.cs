using TMPro;
using UnityEngine;

/// <summary>
/// Just a quick script to manage the names of the objects within the console
/// </summary>
public class ConsoleTextManager : MonoBehaviour
{
    // objects to change text on
    public string titleText;
    public string ButtonLeftText;
    public string ButtonRightText;

    // access to these objects
    public TextMeshPro titleUnityObj;
    public TextMeshPro ButtonLeftUnityObj;
    public TextMeshPro ButtonRightUnityObj;

    // Start is called before the first frame update
    void Start()
    {
        // on start change all of the text to the new text objects
        titleUnityObj.text = titleText;
        ButtonLeftUnityObj.text = ButtonLeftText;
        ButtonRightUnityObj.text = ButtonRightText;
    }
}
