using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public ButtonController buttonController;
    public int select_electric;

    public Button[] buttons;

    // Use this for initialization
    void Start ()
    {
        select_electric = -1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(select_electric);
    }

    public void SetSelectElectric(int select_ele)
    {
        select_electric = select_ele;
    }
    
}
