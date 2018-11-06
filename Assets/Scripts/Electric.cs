using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{

    public int turnLimit;//ターン回数
    private int currentTurn;//現在のターン回数
    public float speed;//速度
    public Vector2 forward;//方向
    public float acceleration;//加速度

    SpriteRenderer sp;//画像
    public Sprite UpSprite;
    public Sprite LeftSprite;

    // Use this for initialization
    void Start()
    {
        currentTurn = 0;
        speed = 6.0f;
        turnLimit = 5;
        acceleration = 1.2f;
        sp=GetComponent<SpriteRenderer>();
        SpriteChange(forward);
    }


    // Update is called once per frame
    void Update()
    {
        

        Move();

    }
    void Move()
    {
        transform.Translate(forward * speed * Time.deltaTime);
    }
    public void TurnForward(float x=0, float y=0)
    {
        //加速する
        speed *= acceleration;

        //ターン回数が上限を超えていなければターンする
        if (currentTurn < turnLimit)
        {
            if (x == 0 && y == 0)
            {
                forward *= -1;
            }
            else
            {
                forward.x = x;
                forward.y = y;
            }
            currentTurn++;
            SpriteChange(forward);
        }
        else
        {
            Explosion();
        }
    }
    //爆破
    void Explosion()
    {
        Debug.Log("Death");
        Destroy(gameObject);
    }
    void SpriteChange(Vector2 dir)
    {
        if (forward.x > 0)
        {//右方向
            sp.sprite = LeftSprite;
            sp.flipX = true;
        }
        else if (forward.x < 0)
        {//左方向
            sp.sprite = LeftSprite;
            sp.flipX = false;
        }
        else if (forward.y > 0)
        {//上方向
            sp.sprite = UpSprite;
            sp.flipY = false;
        }
        else if (forward.y < 0)
        {//下方向
            sp.sprite = UpSprite;
            sp.flipY = true;
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("WTF!" + c.name);
        if (c.gameObject.layer == 13)
        {
            TurnForward();
        }
    }
    void OnTriggerExit2D(Collider2D c)
    {
    }
}
