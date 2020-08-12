using Microsoft.MixedReality.Toolkit.Experimental.UI;
using TMPro;
using UnityEngine;

public class ScrollableContentManager : MonoBehaviour
{
    public ButtonTextHelper PrefabForListObjects;

    private ButtonTextHelper[] listObjectArray;

    private string[] currentMessages;

    public ScrollingObjectCollection scrollableObj;

    public GameObject ContainerObject;

    public TextMeshPro DescriptionPanel;

    [SerializeField]
    private int MaximumAmountOfObjects = 100;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        // set up the arrays to be
        listObjectArray = new ButtonTextHelper[MaximumAmountOfObjects];
        currentMessages = new string[MaximumAmountOfObjects];

        for(int i = 0; i < MaximumAmountOfObjects; i++)
        {
            // set up the game object
            inializeObj(i);

            // set up the string for the game object
            currentMessages[i] = "";
        }

        // go though and set all the text on all of the buttonss
        refreashButtons();

        // update the collection of scrollable objects
        scrollableObj.UpdateCollection();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    private void inializeObj(int index)
    {
        // create the object and place it in the scrollable container
        GameObject newObj = GameObject.Instantiate(PrefabForListObjects.gameObject, this.ContainerObject.transform);
        newObj.name = "ConsoleMessage" + index;

        ButtonTextHelper helper = newObj.GetComponent<ButtonTextHelper>();

        helper.manager = this;

        // then add the text mesh pro object to an array
        listObjectArray[index % MaximumAmountOfObjects] = helper;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public void addNewEntry(string message)
    {
        // work out what the index is because it is going to get used a fair amount
        int i = index % MaximumAmountOfObjects;
        currentMessages[i] = message;
        refreashButtons();
        listObjectArray[i].index = i;
        index++;
        //Debug.Log(index);
    }

    /// <summary>
    /// displays content on the pannel regarding based on the index given
    /// </summary>
    public void DisplayFullMessage(int index)
    {
        DescriptionPanel.text = currentMessages[index % MaximumAmountOfObjects];
    }

    /// <summary>
    /// Refreash all of the text on the given buttons
    /// </summary>
    public void refreashButtons()
    {
        for (int i = MaximumAmountOfObjects - 1; i >= 0; i--)
        {
            // one traverse the object array from least important to imporant
           listObjectArray[i].SetText(currentMessages[(MaximumAmountOfObjects + (index - i)) % MaximumAmountOfObjects]);
        }
    }

    
}
