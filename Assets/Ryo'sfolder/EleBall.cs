using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleBall : MonoBehaviour {

    public float speed;
    Light light;
    float bloom_cnt = 0;
    public float Flash_interval;
	// Use this for initialization
	void Start () {
        light = transform.Find("Point Light").GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();

        bloom_cnt += Mathf.PI * Time.deltaTime * Flash_interval;
        light.intensity = 8 + Mathf.Sin(bloom_cnt) * 1.2f ;

    }

    void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void bloom()
    {
    }
}
