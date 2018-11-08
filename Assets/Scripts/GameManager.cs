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

    public Character Player;
    public Character Enemy;

    public GameObject GameClearSprite;
    public GameObject GameOverSprite;


    // Use this for initialization
    void Start ()
    {
        select_electric = -1;
        life_kari = 3;
        SetLife(life_kari);

        Player = GameObject.Find("Player").GetComponent<Character>();
        Enemy = GameObject.Find("Enemy").GetComponent<Character>();

        GameClearSprite.SetActive(false);
        GameOverSprite.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) &&life_kari<3)++life_kari;
        if (Input.GetKeyDown(KeyCode.DownArrow) && life_kari>1) --life_kari;
        
        SetLife(life_kari);

        //Playerが死んだら
        if (Player.life <= 0)
        {
            GameOver();
        }
        //Enemyが死んだら
        if (Enemy.life <= 0)
        {
            GameClear();
        }
    }

    public void SetSelectElectric(int select_ele)
    {
        select_electric = select_ele;
    }

    public void SetLife(int life)
    {
        life_image.sprite = life_icon[(life-1>0)?life-1:0];
    }
    void GameClear()
    {
        GameClearSprite.SetActive(true);
    }
    void GameOver()
    {
        GameOverSprite.SetActive(true);
    }


}
