using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public const int LIFE_MAX              = 3;           //最大残機
    public const float UPDATE_RATE  = 60.0f;    //更新レート

    public int life;//残機
    public float speed;//速度
    public string type;//キャラクタータイプ

    int invincibleTimer;//無敵時間
    bool isDamage;//攻撃を受けたか

    SpriteRenderer sp;
    // Use this for initialization
    void Start () {
        life = 5;
        invincibleTimer = 0;
        sp = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (life >= LIFE_MAX)
        {
            life = LIFE_MAX;
        }

        if (isDamage)
        {
            if (invincibleTimer >= UPDATE_RATE)
            {
                isDamage = false;
                invincibleTimer = 0;
                sp.color =  Color.white;
            }
            else
            {
                invincibleTimer ++ ;
                if (invincibleTimer % 5 <= 2)
                    sp.color = Color.clear; 
                else
                sp.color = Color.white; 
            }
        }
    }
    //攻撃を食らった
    void Damage()
    {
        if (!isDamage)
        {
            life--;
            isDamage = true;
        }
    }
    //破壊された
    void Crash()
    {

    }
    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("OMG!"+c.name);
        Damage();
    }
}
