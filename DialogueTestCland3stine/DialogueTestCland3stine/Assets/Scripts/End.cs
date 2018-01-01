using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour, TreeNode {

    private string mainText;
    private string choiceText;
    private string needed;
    private string result;
    
    private GameObject background;
    private GameObject ButtonPrefab;
    private Text promptText;

    /**
	 * Standard constructor 
	 * @param needed		variable needed to allow this node in choices ("none" if none)
	 * @param text          choiceText+remainder</br>
	 * choiceText is text that will be displayed to make a choice</br>
	 * remainder's first word is variable to be added to Statics.userVariables, rest is the mainText
	 */
    public End(string needed, string text, GameObject ifield, Text promptText, GameObject background)
    {
        char[] delimiters = { '+' };
        char[] delimitersB = { ' ' };
        this.needed = needed;
        string[] texts = text.Split(delimiters);
        this.choiceText = texts[0];
        string[] info = texts[1].Split(delimitersB, 2);
        this.mainText = info[1];
        this.result = info[0];
        this.promptText = promptText;
        this.background = background;
        this.ButtonPrefab = ifield;
    }

    
    public void run()
    {
        //SET TEXT FIELD HERE System.out.println(mainText);
        clearButtonSpace();
        promptText.text = getText();
        makeButton("Exit",null,0);
        Statics.userVariables.Add(result);
    }

    
    public void attachNode(TreeNode nextNode)
    {
        return;
    }

    
    public string getText()
    {
        return mainText;
    }

    
    public string reqsVar()
    {
        return needed;
    }

    
    public string getChoiceText()
    {
        return choiceText;
    }

    //JH: Set up the buttons that the player will click to indicate their
    //dialogue choices
    public void makeButton(string label, LinkedList<TreeNode> nodes, int num)
    {
        GameObject button; //the object
        DialogueChoiceButtonInit dc; //dialogue choice script object
        Vector3 posVect; //position of this button

        //Instantiate the button, add a DialogueChoiceButtonInit to it,
        //set the text, then add a click listener
        button = Instantiate(ButtonPrefab);
        background.SetActive(true);
        button.transform.SetParent(background.transform);
        button.AddComponent<DialogueChoiceButtonInit>();
        dc = button.GetComponent<DialogueChoiceButtonInit>();
        dc.setNext(nodes);
        posVect = new Vector3(button.transform.position.x, button.transform.position.y + (num * 10), button.transform.position.z);
        button.transform.position = posVect;
        button.GetComponentInChildren<Text>().text = label;
        button.GetComponent<Button>().onClick.AddListener(delegate { dc.Exit(background); });
    }

    public void clearButtonSpace()
    {
        Debug.Log("Clearing Buttons...");
        int children;
        children = background.transform.childCount;
        if (children > 1)
        {
            int counter;
            counter = 1;
            while (counter < children)
            {
                GameObject child;
                child = background.transform.GetChild(counter).gameObject;
                Destroy(child);
                counter++;
            }
        }

    }
}
