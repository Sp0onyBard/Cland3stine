package nodesMethod;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashSet;
import java.util.LinkedList;

/**
 * A bunch of static methods and objects to be used globally
 * @author Naman Goyal, Cland3stine team member
 *
 */
public class Statics {
	public static HashSet<String> userVariables;
	
	/**
	 * Starts the game. Can use to give initial global variables
	 */
	public static void beginGame() {
		userVariables = new HashSet<String>();
		userVariables.add("eweTrust");
	}
	
	
	
	/**
	 * Parses one TreeNode from a string
	 * @param inputString is in form nodeType variableRequired choiceText+(mainText||remainder)
	 * @return a Choices or End node. 
	 * Returns null and prints err statements if there are problems with the text
	 */
	private static TreeNode parseNode(String inputString) {
		//Break into [nodeType, variableRequired, (if end node) result text (else) text]
		String[] info = inputString.split(" ",3);
		
		//If not even three words
		if (info.length!=3) {
			System.err.println("incorrectly formatted");
			return null;
		}
		
		switch (info[0]) {
		case ("choice"):
			return new Choices(info[1],info[2]);
		case ("end"):
			return new End(info[1], info[2]);
		default: //There was a problem with the first word
			System.err.println(info[0]+" given as a nodeType. Incorrect.");
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
	public static TreeNode fileToConvoTree(String inputPath){
		//First get the file
		BufferedReader br=null;
		try {
			br = new BufferedReader(new FileReader(inputPath));
		}
		catch (FileNotFoundException e) {
			System.err.println("File not found");
			e.printStackTrace();
		}
		
		//Then read through it and create a tree
		LinkedList<TreeNode> addTo=null;
		try {
			
			//First line is the first node
			String line = br.readLine().trim(); //get the first nodeString
			addTo = new LinkedList<TreeNode>(); //Use as a stack
			addTo.add(parseNode(line)); //put the first node on the stack
			
			//Then go through the other lines
			while ((line=br.readLine())!=null) {
				line=line.trim();
//				System.out.println(line);    //USE FOR CHECKING TEXT FILES
				if (line.equals("up")) { //if the line is "up"
					addTo.removeFirst();    //remove from the top of the stack
				}
				else {                   //if it's a nodeString
					TreeNode newNode = parseNode(line); //get a node
					addTo.getFirst().attachNode(newNode); //attach it to the top node on the stack
					addTo.addFirst(newNode);            //put it at the top of the stack
				}
			}	
		}
		catch (IOException e) {
			System.err.println("Error reading file");
			e.printStackTrace();
		}
		
		//Close the file
		try {
			br.close();
		}
		catch (IOException e) {
			System.err.println("Error closing file");
			e.printStackTrace();
		}
		
		return addTo.getLast();  //last item in the stack is our top node
	}
}
