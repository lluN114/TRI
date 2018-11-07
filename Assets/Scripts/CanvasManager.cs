using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//画面サイズに関するスクリプト
public class CanvasManager : MonoBehaviour {

    Vector2 ScreenSize;
    Canvas canvas;
    CanvasScaler scaler;

    // Use this for initialization
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        ScreenSize = new Vector2(Screen.width, Screen.height);
        
        //scaler = gameObject.GetComponent<CanvasScaler>();
        //scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        //scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
        //scaler.matchWidthOrHeight = 1;
        //scaler.referenceResolution = ScreenSize;
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

            //scaler.referenceResolution = ScreenSize;
        }
    }
}
