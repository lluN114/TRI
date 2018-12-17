using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSpawner : MonoBehaviour {

    public float spawnDelay;//生成間隔

    public GameObject electric;
    private float timer;
    public bool eUp, eDown, eRight, eLeft;
    public bool isSpawned;


    // Use this for initialization
    void Start () {
        spawnDelay = 2.0f;
        gameObject.tag = "ElectricSpawner";
	}
	
	// Update is called once per frame
	void Update () {

        if (!isSpawned)
        {
            timer += Time.deltaTime;
            if (timer >= spawnDelay)
            {
                isSpawned = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        if(!isSpawned)
        {
            return;
        }

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

        //スポナー初期化
        isSpawned = false;
        timer = 0.0f;
    }
    public void Spawn(Vector2 vec)
    {
        GameObject obj;

        if (!isSpawned)
        {
            return;
        }

        if (vec.x == 0 && vec.y == 0)
        {
            Spawn();
        }
        else
        {
            obj = Instantiate(electric, transform.position, transform.rotation);
            obj.GetComponent<Electric>().forward = vec;
        }

        //スポナー初期化
        isSpawned = false;
        timer = 0.0f;

    }
    public float GetTimer()
    {
        return timer;
    }
}
