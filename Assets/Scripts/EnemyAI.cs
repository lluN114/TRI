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
            StartTouch(GameObject.Find("spawner"));
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
}
