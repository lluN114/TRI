using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTest : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        FadeManager.FadeReady();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            FadeManager.FadeOut(1);
    }
}
