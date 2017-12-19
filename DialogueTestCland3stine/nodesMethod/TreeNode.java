package nodesMethod;

public interface TreeNode {
	
	/**
	 * Runs the next node
	 */
	public void run();
	
	/**
	 * Attaches another node below this one
	 */
	public void attachNode(TreeNode nextNode);
	
	/**
	 * Returns the text stored at this node
	 */
	public String getText();
	
	/**
	 * Returns the (possible) choice text at this node (the text used while making decisions)
	 */
	public String getChoiceText();
	
	/**
	 * Returns the required variable to display / run this node
	 */
	public String reqsVar();
	
}
