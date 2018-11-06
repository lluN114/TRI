using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSpawner : MonoBehaviour {

    public float SPAWN_DELAY;//生成間隔

    public GameObject electric;
    private float timer;
    public bool eUp, eDown, eRight, eLeft;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= SPAWN_DELAY)
        {
            timer = 0;

            Spawn();
        }
	}
    void Spawn()
    {
        GameObject obj;
        if (eUp)
        {
            obj = Instantiate(electric, transform.position, transform.rotation);
            obj.GetComponent<Electric>().forward = new Vector2(0, 1);
        }
        if (eDown)
        {
            obj = Instantiate(electric, transform.position, transform.rotation);
            obj.GetComponent<Electric>().forward = new Vector2(0, -1);
        }
        if (eRight)
        {
            obj = Instantiate(electric, transform.position, transform.rotation);
            obj.GetComponent<Electric>().forward = new Vector2(1, 0);
        }
        if (eLeft)
        {
            obj = Instantiate(electric, transform.position, transform.rotation);
            obj.GetComponent<Electric>().forward = new Vector2(-1, 0);
        }
    }
}
