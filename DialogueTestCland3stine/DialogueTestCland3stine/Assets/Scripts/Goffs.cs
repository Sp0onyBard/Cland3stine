using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Goffs : MonoBehaviour {

    private ModalPanel mp;
    private UnityAction yeAct;
    private UnityAction noAct;
    private UnityAction maybAct;

    public GameObject secondMenu;
    public GameObject thirdMenu;

    void Awake()
    {
        mp = ModalPanel.Instance();

        yeAct = new UnityAction(TestYesFunc);
        noAct = new UnityAction(TestNoFunc);
        maybAct = new UnityAction(TestMaybeFunc);
    }

    public void SwitchBack()
    {
        mp.Choice("OBJECTIVES", yeAct, noAct, maybAct);
        transform.parent.gameObject.SetActive(false);
    }

    void TestYesFunc()
    {
        
        secondMenu.SetActive(true);
    }

    void TestNoFunc()
    {
    }

    void TestMaybeFunc()
    {
        thirdMenu.SetActive(true);
    }
}
