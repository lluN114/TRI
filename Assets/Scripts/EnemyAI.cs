using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Controller {

    //行動間隔
    public float actionDelay;
    public float timer = 0;

	// Use this for initialization
	void Start () {
        actionDelay = 2.0f;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= actionDelay)
        {
            timer = 0;
            StartTouch(FindSpawner());
        }

        FlickState();

        EndTouch(new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)));
        //EndTouch(new Vector2(0,1));
    }
    //AIの思考ルート
    void CheckRoot()
    {
      //ライフによって変更or パターン
    }

    //スポナー設定
    GameObject FindSpawner()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ElectricSpawner");
        int iRand = Random.Range(0, objs.Length);
        return objs[iRand];
    }
}
