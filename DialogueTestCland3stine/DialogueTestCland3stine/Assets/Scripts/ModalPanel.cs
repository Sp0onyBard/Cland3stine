using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

    public Text question;
    //public Image iconImage;
    public Button yes;
    public Button no;
    public Button maybeSo;
    public GameObject menu;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
            {
                Debug.LogError("Ya fuckn suck");
            }
        }
        return modalPanel;
    }

    public void Choice(string question, UnityAction yesev, UnityAction noev, UnityAction maybesoev)
    {
        menu.SetActive(true);
        menu.transform.GetChild(0).gameObject.SetActive(true);
        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener(yesev);
        //yes.onClick.AddListener(ClosePanel);

        no.onClick.RemoveAllListeners();
        no.onClick.AddListener(noev);
        no.onClick.AddListener(ClosePanel);

        maybeSo.onClick.RemoveAllListeners();
        maybeSo.onClick.AddListener(maybesoev);
        maybeSo.onClick.AddListener(ClosePanel);

        this.question.text = question;

        //this.iconImage.gameObject.SetActive(false);
        yes.gameObject.SetActive(true);
        no.gameObject.SetActive(true);
        maybeSo.gameObject.SetActive(true);
    }

    void ClosePanel()
    {
        menu.SetActive(false);
    }
}
