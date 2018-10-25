using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public void Trans(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void OverlaidTrans(string s)
    {
        SceneManager.LoadScene(s, LoadSceneMode.Additive);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
