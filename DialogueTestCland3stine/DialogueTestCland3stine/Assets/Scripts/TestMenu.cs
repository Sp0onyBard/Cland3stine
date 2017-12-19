using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class TestMenu : MonoBehaviour {
    private ModalPanel modalPanel;
    private DisplayManager displayManager;

    private UnityAction yeAct;
    private UnityAction noAct;
    private UnityAction maybAct;

    public GameObject secondMenu;
    public GameObject thirdMenu;


    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        displayManager = DisplayManager.Instance();

        yeAct = new UnityAction(TestYesFunc);
        noAct = new UnityAction(TestNoFunc);
        maybAct = new UnityAction(TestMaybeFunc);
    }
    public void TestButt()
    {
        modalPanel.Choice("OBJECTIVES", yeAct, noAct, maybAct);
    }
    //Send to the Modal Panel to set up the Buttons and Functions to call
    //wrapt into Unity Actions

    void TestYesFunc()
    {
        displayManager.DisplayMessage("Fuqq");
        secondMenu.SetActive(true);
    }

    void TestNoFunc()
    {
        displayManager.DisplayMessage("Fuqq no");
    }

    void TestMaybeFunc()
    {
        displayManager.DisplayMessage("Well Fuqq");
        thirdMenu.SetActive(true);
    }
	
}
