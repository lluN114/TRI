using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float speed;//速度
    public Vector2 forward;//方向
    public float RotTime = 5.0f;//進方向を変える時間

    private float RotTimer = 0;//進行方向を変えるまでの時間

    int ArrowNum = 0;//方向を変える番号

    //SpriteRenderer sp;//画像
    //public Sprite Vertical;
    //public Sprite Horizontal;

    void Start () {
		
	}
	
	void Update () {
        
        EnemyMove();//移動

        RotTimer += Time.deltaTime;
        //一定時間おきに進む方向をランダムで決める
        if(RotTime < RotTimer)
        {
            RotTimer = 0;
            ArrowNum = Random.Range(0, 4);
            EnemyRotate();
        }
	}

    void EnemyMove()
    {
        //向いている方向に移動
        transform.Translate(forward * speed * Time.deltaTime);
    }

    void EnemyRotate()
    {
        switch (ArrowNum)
        {
            case 0:
                //上に移動
                //sp.sprite = Vertical;
                //sp.flipY = false;
                forward = new Vector2(0, 1);
                break;

            case 1:
                //下に移動
                //sp.sprite = Vertical;
                //sp.flipY = true;
                forward = new Vector2(0, -1);
                break;

            case 2:
                //右に移動
                //sp.sprite = Horizontal;
                //sp.flipX = true;
                forward = new Vector2(1, 0);
                break;

            case 3:
                //左に移動
                //sp.sprite = Horizontal;
                //sp.flipX = false;
                forward = new Vector2(-1, 0);
                break;
        }
    }
    void WallTurnEnemy(float x = 0, float y = 0)
    {
        //壁にぶつかったら進む方向を強制的に反転
        if (x == 0 && y == 0)
        {
            forward *= -1;
        }
        else
        {
            forward.x = x;
            forward.y = y;
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        //レイヤー13番目(Wall)にぶつかったかの判定
        if (c.gameObject.layer == 13)
        {
            WallTurnEnemy();
        }
    }
}
