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
        light = transform.FindChild("Point Light").GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();

        bloom_cnt += Time.deltaTime * Flash_interval;
        light.intensity = Mathf.Sin(bloom_cnt) * 0.5f + 1;

    }

    void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void bloom()
    {
    }
}
