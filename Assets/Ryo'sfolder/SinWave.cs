using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWave : MonoBehaviour {
    public float x = 2f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x
   , Mathf.Sin(Time.frameCount * x) * 0.5f + 0.5f, transform.position.z);
    }
}
