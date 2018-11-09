using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public ButtonController buttonController;
    public int select_electric;


    public Image life_image;
    public Sprite[] life_icon;

    public Character Player;
    public Character Enemy;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player").GetComponent<Character>();
        Enemy = GameObject.Find("Enemy").GetComponent<Character>();

        select_electric = -1;
        Player.life = 3;
        SetLife(Player.life);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) &&Player.life<3)Player.life++;
        if (Input.GetKeyDown(KeyCode.DownArrow) && Player.life>1) Player.life++;
        
        SetLife(Player.life);

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
        Debug.Log("CLEAR");
    }
    void GameOver()
    {
        Debug.Log("GAME OVER");
    }
}
