using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

/**
 * A bunch of static methods and objects to be used globally
 * @author Naman Goyal, Cland3stine team member
 *  adapted for Unity and C# by Julia Holgado, Cland3stine team member
 */

public class Statics : MonoBehaviour {

    public static HashSet<string> userVariables;

    /**
	 * Starts the game. Can use to give initial global variables
	 */
    public static void beginGame()
    {
        userVariables = new HashSet<string>();
        userVariables.Add("eweTrust");
    }



    /**
	 * Parses one TreeNode from a string
	 * @param inputString is in form nodeType variableRequired choiceText+(mainText||remainder)
	 * @return a Choices or End node. 
	 * Returns null and prints err statements if there are problems with the text
	 */
    private static TreeNode parseNode(string inputString, GameObject iField, Text promptText, GameObject background)
    {
        //Break into [nodeType, variableRequired, (if end node) result text (else) text]
        char[] delim = { ' ' };
        string[] info = inputString.Split(delim, 3);

        //If not even three words
        if (info.Length != 3)
        {
            Debug.Log("incorrectly formatted");
            return null;
        }

        switch (info[0])
        {
            case ("choice"):
                return new Choices(info[1], info[2], iField, promptText, background);
            case ("end"):
                return new End(info[1], info[2], iField, promptText, background);
            default: //There was a problem with the first word
                Debug.Log(info[0] + " given as a nodeType. Incorrect.");
                return null;
        }
    }

    /**
	 * Makes a conversation tree from a file</br>
	 * In the file each line is either a string representation of a node or "up"</br>
	 * "up" controls where new nodes are being added</br>
	 * each node is in form nodeType variableRequired choiceText+(mainText||remainder)
	 * @param inputPath       place the text file is stored
	 * @return                top node of the conversation tree
	 */
    public static TreeNode fileToConvoTree(string inputPath, GameObject iField, Text promptText, GameObject background)
    {
        //First get the file
        using (System.IO.StreamReader sr = System.IO.File.OpenText("ewe.txt"))
        {



            //BufferedReader br = null;
            //try
            //{
            //    br = new BufferedReader(new FileReader(inputPath));
            //}
            //catch (FileNotFoundException e)
            //{
            //    Debug.Log("File not found");
            //    e.printStackTrace();
            //}

            //Then read through it and create a tree
            LinkedList<TreeNode> addTo = null;
            try
            {

                //First line is the first node
                string line = sr.ReadLine().Trim(); //get the first nodeString
                addTo = new LinkedList<TreeNode>(); //Use as a stack
                addTo.AddFirst(parseNode(line, iField,promptText, background)); //put the first node on the stack

                //Then go through the other lines
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    //				System.out.println(line);    //USE FOR CHECKING TEXT FILES
                    if (line.Equals("up"))
                    { //if the line is "up"
                        addTo.RemoveFirst();    //remove from the top of the stack
                    }
                    else {                   //if it's a nodeString
                        TreeNode newNode = parseNode(line, iField, promptText, background); //get a node
                                                            //addTo.getFirst().attachNode(newNode); //attach it to the top node on the stack
                        addTo.First.Value.attachNode(newNode);
                        addTo.AddFirst(newNode);            //put it at the top of the stack
                    }
                }
            }
            catch (IOException e)
            {
                Debug.Log("Error reading file");
                e.ToString();
            }

            //Close the file
            try
            {
                sr.Close();
            }
            catch (IOException e)
            {
                Debug.Log("Error closing file");
                e.ToString();
            }


            return addTo.Last.Value;  //last item in the stack is our top node
        }
    }
}
