using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public const float UPDATE_RATE = 60.0f;

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

        if (isDamage)
        {
            if (invincibleTimer >= UPDATE_RATE)
            {
                isDamage = false;
                invincibleTimer = 0;
                sp.color = sp.color = Color.white;
            }
            else
            {
                invincibleTimer ++ ;
                if (invincibleTimer % 5 <= 2)
                    sp.color = Color.clear; 
                else
                sp.color = sp.color = Color.white; 
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
