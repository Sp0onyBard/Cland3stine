using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TreeNode {

    /**
	 * Runs the next node
	 */
    void run();

    /**
	 * Attaches another node below this one
	 */
    void attachNode(TreeNode nextNode);

    /**
	 * Returns the text stored at this node
	 */
    string getText();

    /**
	 * Returns the (possible) choice text at this node (the text used while making decisions)
	 */
    string getChoiceText();

    /**
	 * Returns the required variable to display / run this node
	 */
    string reqsVar();

}
