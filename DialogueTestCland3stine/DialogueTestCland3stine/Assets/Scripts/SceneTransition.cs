using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    //private static Dictionary<string, int> tracker = new Dictionary<string, int>();
    public VariableTable vt;

    private static bool called = false;
    //public Text interact;

    // Use this for initialization
    void Awake() {
        if (!called)
        {
            vt.addCounter("MovCount", 0);
            //tracker.Add("MovCount", 0);
            called = true;
        }       
    }        

    void OnTriggerStay(Collider other)
    {
        //Debug.Log(tracker["MovCount"]);
        Debug.Log(SceneManager.GetActiveScene().name);
        //Debug.Log(tracker["MovCount"] > 2);
        if (Input.GetKeyDown(KeyCode.Return) && (SceneManager.GetActiveScene().name == "Scene1"))
        {
            if (vt.checkCounter("MovCount") > 2)
            {
                SceneManager.LoadScene("Scene3");
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene3"));
            }
            else
            {
                vt.updateCounter("MovCount",vt.checkCounter("MovCount") + 1);
                SceneManager.LoadScene("Scene2");
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene2"));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return) && (SceneManager.GetActiveScene().name == "Scene2"))
            {
                SceneManager.LoadScene("Scene1");
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene1"));
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) && (SceneManager.GetActiveScene().name == "Scene3"))
        {
            SceneManager.LoadScene("Scene1");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene1"));
        }
    }
	
	
	
}
