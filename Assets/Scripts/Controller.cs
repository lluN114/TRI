using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float margin = 0.5f; //フリック判定までの猶予距離

    //タッチされた位置と離された位置を格納する変数
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    //オブジェクトタップ判定
    public bool isTouch = false;

    //現在衝突しているオブジェクト
    public GameObject hitObj;

    void Start() {
        margin = 0.5f;
    }

    // Update is called once per frame
    void Update() {
        FlickState();
    }

    public void FlickState()
    {
        //タッチされているときの挙動
        if (isTouch)
        {
            //GetDirection();
            //移動中の位置を保存
            touchEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    public void StartTouch(Vector2 input)
    {
        //タッチした位置を保存
        touchStartPos = input;
        Collider2D collisionObj = Physics2D.OverlapPoint(touchStartPos);

        //例キャストをして当たったもの(最上層)を検出
        try
        {
            hitObj = Physics2D.Raycast(touchStartPos, -Vector2.up).collider.gameObject;
            if (hitObj != null)
            {
                Debug.Log("hit object is " + hitObj.name);
                isTouch = true;
            }
        }
        catch
        {
            Debug.Log("Object NULL");
        }
    }
    public void StartTouch(GameObject obj)
    {
        touchStartPos = new Vector2(0, 0);
        //オブジェクトを設定
        hitObj = obj;
        isTouch = true;
    }

    public void EndTouch(Vector2 input)
    {
        //離した位置を保存
        touchEndPos = input;

        //保存したオブジェクトへのアクション
        FlickCheck(ref hitObj, GetDirection(touchStartPos, touchEndPos));

        isTouch = false;
    }

    Vector2 GetDirection(Vector2 start,Vector2 end)
    {
        //離された座標からタッチされた座標を引いて各変数に格納
        float directionX = end.x - start.x;
        float directionY = end.y - start.y;
        
        //フリック範囲が猶予以内ならフリック判定をなくす
        if (Vector2.Distance(start, end) <= margin)
        {
            return new Vector2(0, 0);
        }

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (directionY < directionX)
            {
                //右向きにフリック
                return new Vector2(1, 0);
            }
            else if (directionY > directionX)
            {
                //左向きにフリック
                return new Vector2(-1, 0);
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (directionX < directionY)
            {
                //上向きにフリック
                return new Vector2(0, 1);
            }
            else if (directionX > directionY)
            {
                //下向きのフリック
                return new Vector2(0, -1);
            }
        }
        return new Vector2(0, 0);
    }
    void FlickCheck(ref GameObject obj,Vector2 vec)
    {
        if (obj == null)
        {
            return;
        }
        Debug.Log(obj.tag);

        switch (obj.tag)
        {
            case "Player":
                break;
            case "Enemy":
                break;
            case "Electric":
                obj.GetComponent<Electric>().TurnForward(vec.x, vec.y);
                break;
            case "DestroyArea":
                break;
            case "Wall":
                break;
            case "ElectricSpawner":
                obj.GetComponent<ElectricSpawner>().Spawn(tag,vec);
                Debug.Log("SPAWN");
                break;
            default:
                Debug.Log("ON");
                break;
        }
    }

}