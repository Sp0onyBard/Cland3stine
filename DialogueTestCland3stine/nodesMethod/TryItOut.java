package nodesMethod;

public class TryItOut {
	public static void main(String[] args) {
		Statics.beginGame();
		TreeNode EweTree = Statics.fileToConvoTree("inputs/ewe.txt");
		EweTree.run();
	}
}
