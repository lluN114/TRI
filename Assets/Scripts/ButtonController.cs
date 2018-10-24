using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ReturnButtonName()
    {
        int play_button;
        switch (transform.name)
        {
            case "Button1":
                play_button = 1;
                break;
            case "Button2":
                play_button = 2;
                break;
            case "Button3":
                play_button = 3;
                break;
            default:
                play_button = -1;
                break;
        }

        //Debug.Log(play_button);
        gameManager.SetSelectElectric(play_button);
    }
}
