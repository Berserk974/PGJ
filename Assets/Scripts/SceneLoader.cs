using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour {

    [SerializeField]
    private List<string> sceneNames;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene0()
    {
        LoadScene(0);
    }

    public void LoadScene(string s)
    {
        Application.LoadLevel(s);
    }

    public void LoadScene(int i)
    {
        Application.LoadLevel(sceneNames[i]);
    }
}
