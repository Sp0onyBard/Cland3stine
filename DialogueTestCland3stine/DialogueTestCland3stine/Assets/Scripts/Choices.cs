using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

/**
 * Implementation of TreeNode
 * to represent a node that allows you to make a choice
 * @author Naman Goyal, Cland3stine team member
 *  adapted for Unity and C# by Julia Holgado, Cland3stine team member
 */
public class Choices: MonoBehaviour, TreeNode {

    private List<TreeNode> nextNodes;
    private string mainText;
    private string choiceText;
    private string needed;
    private Text dialogueText;
    private GameObject ButtonPrefab;
    private GameObject background;
    private Text promptText;

    /**
	 * Standard constructor
	 * @param needed		variable needed to allow this node in choices ("none" if none)
	 * @param text          choiceText+mainText</br>
	 * choiceText is text that will be displayed to make a choice</br>
	 * mainText is main text stored here
	 */
    public Choices(string needed, string text, GameObject iField, Text promptText, GameObject background)
    {
        char[] delimiters = {'+'};
        this.needed = needed;
        string[] texts = text.Split(delimiters);
        this.choiceText = texts[0];
        this.mainText = texts[1];
        nextNodes = new List<TreeNode>();
        this.background = background;
        this.promptText = promptText;
        this.ButtonPrefab = iField;
        //dialogueText = dText;
        
    }

    public void run()
    {
        clearButtonSpace();
        //First get rid of all options that require a var that isn't present
        LinkedList<TreeNode> varNodes = new LinkedList<TreeNode>();
        foreach (TreeNode i in nextNodes)
        {
            if (i.reqsVar().Equals("none") || Statics.userVariables.Contains(i.reqsVar()))
            {
                varNodes.AddLast(i);
            }
        }
        //Console version, graphic version will obviously be different

        //JH: Set text for prompt, then add each of the choice buttons
        
        //Scanner in = new Scanner(System.in); //User input for console version
        //System.out.println(getText());
        promptText.text = getText();
        promptText.enabled = true;
        //put prompts in dialogue box
        string inlabel;
        for (int i = 0; i < varNodes.Count; i++)
        {         
            inlabel = (i + 1) + " : " + varNodes.ElementAt(i).getChoiceText();
            makeButton(inlabel, varNodes, i);
        }
        //System.out.println("Type your choice (integer)");
        //Debug.Log(dialogueText.text);
        //int x;
        //int.Parse()
        ////Debug.Log(x);
        //if (x == 0)
        //{
        //    varNodes.ElementAt(x).run();
        //}
        //else
        //{
        //    varNodes.ElementAt(x - 1).run();
        //}        
		//in.close(); //User input for console version
    }

    public string getText()
    {
        return mainText;
    }

    public void attachNode(TreeNode nextNode)
    {
        //Debug.Log(mainText + " BEFORE: " + nextNodes.Count);
        //Debug.Log("ADDING: " + nextNode.getText());
        //Debug.Log(nextNode.getText());
        //Debug.Log("CONTAINS? " + nextNodes.Contains(nextNode));
        //Debug.Log("EQUALITY CHECK" + nextNode.Equals(nextNodes.First()));
        nextNodes.Add(nextNode);
        //Debug.Log(mainText + " AFTER: " + nextNodes.Count);
        //Debug.Log("");
        //Debug.Log("");
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
        posVect = new Vector3(button.transform.position.x, button.transform.position.y + (num*10), button.transform.position.z);
        button.transform.position = posVect;
        button.GetComponentInChildren<Text>().text = label;
        button.GetComponent<Button>().onClick.AddListener(delegate { dc.Proceed(); });
    }

    public void clearButtonSpace()
    {
        Debug.Log("Clearing Buttons...");
        int children;
        children = background.transform.childCount;
        if(children > 1)
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
