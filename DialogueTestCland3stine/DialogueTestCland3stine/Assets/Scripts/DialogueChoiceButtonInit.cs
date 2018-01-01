using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DialogueChoiceButtonInit : MonoBehaviour {

    private LinkedList<TreeNode> listNext;
    private List<TreeNode> listNextlist;
    //private int id;
    //public delegate void ClickedAction();
    //public static event ClickedAction OnClickedAction;

    public void Proceed()
    {
        //gets the node this choice corresponds to and runs it
        Text choiceText;
        string[] splitText;
        char[] delimiters = { ':' };
        //Debug.Log("Clicking worked");
        choiceText = gameObject.GetComponentInChildren<Text>();
        splitText = choiceText.text.Split(delimiters);
        //Debug.Log(splitText[0]);
        TreeNode toRun = getNodey(int.Parse(splitText[0]));
        toRun.run();
    }

    public void Exit(GameObject bg)
    {
        bg.SetActive(false);
    }

    public void setNext(LinkedList<TreeNode> listNext)
    {
        this.listNext = listNext;
    }
    
    //Assume number passed exists in list
    public TreeNode getNodey(int choiceNum)
    {
        LinkedListNode<TreeNode> starter = listNext.First;
        bool done = false;
        int i = 1;
        while (!done)
        {
            if (i == choiceNum)
            {
                return starter.Value;
            }
            else
            {
                starter = starter.Next;
                i++;
            }
        }
        return null;
    }
}
