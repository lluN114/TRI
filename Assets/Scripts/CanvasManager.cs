using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//画面サイズに関するスクリプト
public class CanvasManager : MonoBehaviour {

    Vector2 ScreenSize;
    Canvas canvas;
    CanvasScaler scaler;
    public Image image;

    // Use this for initialization
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        ScreenSize = new Vector2(Screen.width, Screen.height);
        Vector2 size = image.GetComponent<RectTransform>().sizeDelta;

        image.rectTransform.sizeDelta=new Vector2(ScreenSize.x,ScreenSize.y*0.4f);

        scaler = gameObject.GetComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = ScreenSize;
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

            scaler.referenceResolution = ScreenSize;

            //image.rectTransform.rect.Set(0, 0, ScreenSize.x, ScreenSize.y * 0.4f);
            Debug.Log("x,y=" + ScreenSize.x + "," + ScreenSize.y);

            //image.rectTransform.sizeDelta = new Vector2(ScreenSize.x, ScreenSize.y * 0.4f);

        }
    }
}
