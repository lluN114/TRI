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

    public GameObject GameClearSprite;
    public GameObject GameOverSprite;
    public GameObject GameOverBgSprite;

    public Text lifeText;

    //ゲームクリア時のオブジェクト
    public Canvas ClearObject;
    //失敗したときのオブジェクト
    public Canvas MissObject;

    public enum GAMEMODE
    {
        STANDBY,GAME,CLEAR,MISS
    };
    public GAMEMODE gMode;
    public static bool isGameStart;


    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player").GetComponent<Character>();
        Enemy = GameObject.Find("Enemy").GetComponent<Character>();
        
        select_electric = -1;
        Player.life = 3;
        SetLife(Player.life);

        GameClearSprite.SetActive(false);
        GameOverSprite.SetActive(false);

        FadeManager.FadeReady();

        gMode = GAMEMODE.STANDBY;
        isGameStart = false;

        ClearObject.gameObject.SetActive(false);
        MissObject.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update ()
    {
        if (FadeManager.GetGameStart()&&gMode==GAMEMODE.STANDBY)
        {
            gMode = GAMEMODE.GAME;
        }
        //if (Input.GetKeyDown(KeyCode.UpArrow) &&Player.life<3)Player.life++;
        //if (Input.GetKeyDown(KeyCode.DownArrow) && Player.life>1) Player.life++;
        
        if (gMode == GAMEMODE.GAME)
        {
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
    }

    public void SetSelectElectric(int select_ele)
    {
        select_electric = select_ele;
    }

    public void SetLife(int life)
    {
        life_image.sprite = life_icon[(life-1>0)?life-1:0];
        lifeText.text = life.ToString();
        if (life < 0) life = 0;
    }
    void GameClear()
    {
        GameClearSprite.SetActive(true);
        ClearObject.gameObject.SetActive(true);
        gMode = GAMEMODE.CLEAR;
    }
    void GameOver()
    {
        GameOverBgSprite.SetActive(true);
        GameOverSprite.SetActive(true);
        MissObject.gameObject.SetActive(true);
        gMode = GAMEMODE.MISS;
    }
}
