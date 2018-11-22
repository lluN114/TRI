using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    bool input;

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
        input = false;

        FadeManager.FadeIn();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && !input)
        {
            input = true;
            FadeManager.FadeOut(2);
        }
	}
}
