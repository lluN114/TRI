using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public ButtonController buttonController;
    public int select_electric;

    public int life_kari;

    public Image life_image;
    public Sprite[] life_icon;
    // Use this for initialization
    void Start ()
    {
        select_electric = -1;
        life_kari = 3;
        SetLife(life_kari);
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

    public void SetLife(int life)
    {
        life_kari = life;

        life_image.sprite = life_icon[(life_kari-1>0)?life_kari-1:0];
    }
    

}
