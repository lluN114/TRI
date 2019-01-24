using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElectric : Electric {

	// Use this for initialization
	public override void Start () {
        base.Start();
        name = "EnemyElectric";
        gameObject.layer = 11;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    public override void OnTriggerEnter2D(Collider2D c)
    {
        base.OnTriggerEnter2D(c);

        if (c.gameObject.layer == 10)
        {
            Explosion();
        }

    }
}
