using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElectric : Electric {

	// Use this for initialization
	public override void Start () {
        base.Start();
        name = "PlayerElectric";
        gameObject.layer = 10;
    }

    // Update is called once per frame
    public override void Update () {
        base.Update();
	}

    public override void OnTriggerEnter2D(Collider2D c)
    {
        base.OnTriggerEnter2D(c);

        if (c.gameObject.layer == 11)
        {
            Explosion();
        }

    }
}
