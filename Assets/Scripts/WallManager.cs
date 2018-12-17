using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {

    public BoxCollider2D colU, colD, colR, colL;


    // Use this for initialization
    void Start()
    {
        SetWall();
        SetWallSize(-5  ,5);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetWall()
    {
        //上方向
        colU = GameObject.Find("WALL-UP").GetComponent<BoxCollider2D>();
        //右方向
        colR = GameObject.Find("WALL-RIGHT").GetComponent<BoxCollider2D>();
        //下方向
        colD = GameObject.Find("WALL-DOWN").GetComponent<BoxCollider2D>();
        //左方向
        colL = GameObject.Find("WALL-LEFT").GetComponent<BoxCollider2D>();
    }

    //壁の大きさの設定
    void SetWallSize(float min,float max)
    {
        //上下の長さ
        colU.size = new Vector2(max * 2 + 3, 1);
        colD.size = new Vector2(max * 2 + 3, 1);

        colL.offset = new Vector2(min - 2, 0);
        colR.offset = new Vector2(max + 2, 0);


    }

}
