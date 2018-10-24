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

        if (Input.GetKeyDown(KeyCode.W))
        {
            TurnForward(new Vector2(0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            TurnForward(new Vector2(-1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            TurnForward(new Vector2(1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            TurnForward(new Vector2(0, -1));
        }

        Move();

    }
    void Move()
    {
        transform.Translate(forward.normalized * speed * Time.deltaTime);
    }
    public void TurnForward(Vector2 dir)
    {
        //ターン回数が上限を超えていなければターンする
        if (currentTurn < turnLimit)
        {
            forward = dir;
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
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.layer == 12)
            forward *= -1;

    }
}
