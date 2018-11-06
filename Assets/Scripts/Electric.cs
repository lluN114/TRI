using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{

    public int turnLimit;//ターン回数
    private int currentTurn;//現在のターン回数
    public float speed;//速度
    public Vector2 forward;//方向

    // Use this for initialization
    void Start()
    {
        currentTurn = 0;
        speed = 6.0f;
        turnLimit = 5;
    }


    // Update is called once per frame
    void Update()
    {
        

        Move();

    }
    void Move()
    {
        transform.Translate(forward.normalized * speed * Time.deltaTime);
    }
    public void TurnForward(float x=0, float y=0)
    {

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
