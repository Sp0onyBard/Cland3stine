using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueControl : MonoBehaviour {

    public Text dialogue;
    public GameObject panel;
    public Text interactionText;
    public GameObject ButtonPrefab;
    public Text promptText;
    public GameObject background;

    private int talkCount;
    private bool inConvo;
    private bool inRange;
    private bool inProgress;
    private string[] dtext;

    private TreeNode ewetree;

    // Use this for initialization
    void Start()
    {

        //dialogue.enabled = false;
        //panel.SetActive(false);
        interactionText.enabled = false;
        talkCount = 0;
        inConvo = false;
        inRange = false;
        dtext = new string[]{"", "Hello, stranger!", "Aren't you a funny one?", "", "Looking for a way to the upper levels?", "Tough luck!"};
        Statics.beginGame();
        ewetree = Statics.fileToConvoTree("ewe.txt", ButtonPrefab, promptText, background);
    }
    
	
	// Update is called once per frame
	void Update () {

        //StartCoroutine(updateDialogue());
        
    }

    public void startTalking()
    {
        ewetree.run();
    }

    void OnTriggerStay(Collider other)
    {
        //inRange = true;
        interactionText.enabled = true;
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {

            ewetree.run();
                //interactionText.enabled = false;
                //ShowDialogue();
            
        }
        if(dtext[talkCount] == "")
        {
            //HideDialogue();
        }
    }

    void OnTriggerExit(Collider other)
    {
        inRange = false;
        //interactionText.enabled = false;
    }

    void ShowDialogue()
    {
        talkCount++;
        dialogue.enabled = true;
        dialogue.text = dtext[talkCount];
        panel.SetActive(true);
        inConvo = true;
    }

    void HideDialogue()
    {
        dialogue.enabled = false;
        panel.SetActive(false);
        inConvo = false;
    }
}
