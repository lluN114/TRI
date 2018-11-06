using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//画面サイズに関するスクリプト
public class CanvasManager : MonoBehaviour {

    Vector2 ScreenSize;
    Canvas canvas;

    // Use this for initialization
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        ScreenSize = new Vector2(Screen.width, Screen.height);
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetScreen();
	}
    void GetScreen()
    {
      if(ScreenSize.x != Screen.width || ScreenSize.y != Screen.height)
        {
            ScreenSize = new Vector2(Screen.width, Screen.height);


        }
    }
}
