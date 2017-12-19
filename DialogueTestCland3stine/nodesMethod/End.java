package nodesMethod;

public class End implements TreeNode {
	private String mainText;
	private String choiceText;
	private String needed;
	private String result;
	
	/**
	 * Standard constructor 
	 * @param needed		variable needed to allow this node in choices ("none" if none)
	 * @param text          choiceText+remainder</br>
	 * choiceText is text that will be displayed to make a choice</br>
	 * remainder's first word is variable to be added to Statics.userVariables, rest is the mainText
	 */
	public End(String needed, String text) {
		this.needed=needed;
		String[] texts = text.split("\\+");
		this.choiceText = texts[0];
		String[] info = texts[1].split(" ",2);
		this.mainText=info[1];
		this.result=info[0];
	}
	
	@Override
	public void run() {
		System.out.println(mainText);
		Statics.userVariables.add(result);
		}
	
	@Override
	public void attachNode(TreeNode nextNode) {
		return;
	}
	
	@Override
	public String getText() {
		return mainText;
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
