using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //押されたら
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartTouch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        FlickState();

        //離されたら
        if (Input.GetKeyUp(KeyCode.Mouse0) && isTouch == true)
        {
            EndTouch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
