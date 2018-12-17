using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character {

    Vector2 forward;

	// Use this for initialization
	public override void Start () {
		
	}
    public override void Update()
    {
        Move();

    }
    public override void Move()
    {
        transform.Translate(forward * Time.deltaTime);
    }
    //攻撃をする
    public virtual void Attack()
    {

    }
    //移動パターン
    public virtual void CheckNecxtState()
    {
        int iRand = Random.Range(0, 5);
        switch(iRand)
        {
            case 0:
                forward = new Vector2(0, 1);
                break;
            case 1:
                forward = new Vector2(0, -1);
                break;
            case 2:
                forward = new Vector2(1, 0);
                break;
            case 3:
                forward = new Vector2(-1, 0);
                break;
            default:
                forward = new Vector2(0, 0);
                break;
        }
    }
}
