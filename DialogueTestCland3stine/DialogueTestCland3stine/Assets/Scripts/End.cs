using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour, TreeNode {

    private string mainText;
    private string choiceText;
    private string needed;
    private string result;
    private Text promptText;
    private GameObject background;

    /**
	 * Standard constructor 
	 * @param needed		variable needed to allow this node in choices ("none" if none)
	 * @param text          choiceText+remainder</br>
	 * choiceText is text that will be displayed to make a choice</br>
	 * remainder's first word is variable to be added to Statics.userVariables, rest is the mainText
	 */
    public End(string needed, string text, Text promptText, GameObject background)
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
    }

    
    public void run()
    {
        //SET TEXT FIELD HERE System.out.println(mainText);
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
}
