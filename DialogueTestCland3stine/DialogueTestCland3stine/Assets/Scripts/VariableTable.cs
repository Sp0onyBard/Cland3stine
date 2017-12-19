using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableTable : MonoBehaviour {

    private static Dictionary<string, int> counters = new Dictionary<string, int>();
    private static Dictionary<string, bool> flags = new Dictionary<string, bool>();

    private static bool init = false;

    // Use this for initialization
    void Start () {
       
	}
	
	public void updateCounter(string name, int val)
    {
        if (counters.ContainsKey(name))
        {
            counters[name] = val;
        }
        else
        {
            Debug.Log("Key not in table");
        }
    }

    public void updateFlag(string name, bool val)
    {
        if (flags.ContainsKey(name))
        {
            flags[name] = val;
        }
        else
        {
            Debug.Log("Key not in table");
        }
    }

    public void addCounter(string name, int val)
    {
        if (counters.ContainsKey(name))
        {
            Debug.Log("Key already present");
        }
        else
        {
            counters.Add(name, val);
        }
    }

    public void addFlag(string name, bool val)
    {
        if (flags.ContainsKey(name))
        {
            Debug.Log("Key already present");
        }
        else
        {
            flags.Add(name, val);
        }
    }

    public bool checkFlag(string name)
    {
        return flags[name];
        
    }

    public int checkCounter(string name)
    {
        return counters[name];
    }
}
