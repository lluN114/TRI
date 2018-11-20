using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDelate : MonoBehaviour {
    public float delete_time;
    // Use this for initialization
    float delate_timer;
	void Start () {
        delate_timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        delate_timer += Time.deltaTime;
        if(delate_timer > delete_time)
        {
            Destroy(this.gameObject);
        }
	}
}
