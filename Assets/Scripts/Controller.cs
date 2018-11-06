using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float margin = 20.0f; //フリック判定までの猶予距離

    //タッチされた位置と離された位置を格納する変数
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private string Direction;

    //オブジェクトタップ判定
    private bool flg = false;

    private Electric FrickElectric;
    

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Flick();
    }

    void Flick()
    {
        //タッチされたら
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Vector2 TapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D CollisionObj = Physics2D.OverlapPoint(TapPoint);

            if (CollisionObj)
            {
                RaycastHit2D HitObj = Physics2D.Raycast(TapPoint, -Vector2.up);
                if (HitObj)
                {
                    Debug.Log("hit object is " + HitObj.collider.gameObject.name);
                    try
                    {
                        FrickElectric = HitObj.collider.gameObject.GetComponent<Electric>();
                    }
                    catch
                    {
                        Debug.Log("NO[ELECTRIC]");
                    }
                    //タッチした位置を保存
                    touchStartPos = new Vector2(Input.mousePosition.x,
                                                Input.mousePosition.y);
                    flg = true;
                }
            }


            


        }
        //離されたら
        if (Input.GetKeyUp(KeyCode.Mouse0)&&flg == true)
        {
            //離した位置を保存
            touchEndPos = new Vector2(Input.mousePosition.x,
                                      Input.mousePosition.y);
            flg = false;
            GetDirection();
        }
    }
    void GetDirection()
    {
        //離された座標からタッチされた座標を引いて各変数に格納
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (margin < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }
            else if (-margin > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (margin < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }
            else if (-margin > directionY)
            {
                //下向きのフリック
                Direction = "down";
            }
        }
        else
        {
            //タッチを検出
            Direction = "touch";
        }
        FlickProcess(ref FrickElectric);
    }
    void FlickProcess(ref Electric elec) { 

        switch (Direction)
        {
            case "up":
                //上フリックされた時の処理
                Debug.Log("上");
                elec.TurnForward(0, 1);
                break;

            case "down":
                //下フリックされた時の処理
                Debug.Log("下");
                elec.TurnForward(0, -1);
                break;

            case "right":
                //右フリックされた時の処理
                Debug.Log("右");
                elec.TurnForward(1, 0);
                break;

            case "left":
                //左フリックされた時の処理
                Debug.Log("左");
                elec.TurnForward( -1,0);
                break;

            case "touch":
                //タッチされた時の処理
                Debug.Log("タップ");
                break;
        }
    }

}