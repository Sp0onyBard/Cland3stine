package nodesMethod;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.Scanner;
/**
 * Implementation of TreeNode
 * to represent a node that allows you to make a choice
 * @author Naman Goyal, Cland3stine team member
 *
 */
public class Choices implements TreeNode{
	private HashSet<TreeNode> nextNodes;
	private String mainText;
	private String choiceText;
	private String needed;
	
	/**
	 * Standard constructor
	 * @param needed		variable needed to allow this node in choices ("none" if none)
	 * @param text          choiceText+mainText</br>
	 * choiceText is text that will be displayed to make a choice</br>
	 * mainText is main text stored here
	 */
	public Choices(String needed, String text) {
		this.needed = needed;
		String[] texts = text.split("\\+");
		this.choiceText = texts[0];
		this.mainText = texts[1];
		nextNodes = new HashSet<TreeNode>();
	}
	
	@Override
	public void run() {
		//First get rid of all options that require a var that isn't present
		LinkedList<TreeNode> varNodes = new LinkedList<TreeNode>();
		for (TreeNode i:nextNodes) {
			if (i.reqsVar().equals("none")||Statics.userVariables.contains(i.reqsVar())) {
				varNodes.add(i);
			}
		}
		//Console version, graphic version will obviously be different
		Scanner in = new Scanner(System.in);
		System.out.println(getText());
		for (int i=0;i<varNodes.size();i++) {
			System.out.println((i+1)+" : "+varNodes.get(i).getChoiceText());
		}
		System.out.println("Type your choice (integer)");
		varNodes.get(in.nextInt()-1).run();
		in.close();
	}
	
	@Override
	public String getText() {
		return mainText;
	}

	@Override
	public void attachNode(TreeNode nextNode) {
		nextNodes.add(nextNode);
	}
	
	@Override
	public String reqsVar() {
		return needed;
	}

	@Override
	public String getChoiceText() {
		return choiceText;
	}
}
