using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSpawner : MonoBehaviour {

    public float spawnDelay;//生成間隔

    public GameObject PlayerElectric;
    public GameObject EnemyElectric;
    private float timer;
    public bool eUp, eDown, eRight, eLeft;
    public bool isSpawned;
    

    // Use this for initialization
    void Start () {
        spawnDelay = 2.0f;

        name = "spawner";
        tag = "ElectricSpawner";

        eUp = false;
        eDown = false;
        eRight = false;
        eLeft = false;

        int iRand = Random.Range(0, 100)%2;
        if (iRand == 0)
        {
            eUp = true;
            eDown = true;
        }else
        {
            eRight = true;
            eLeft = true;
        }
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
            Spawn("Player");
        }
    }
    public void Spawn(string sTag)
    {
        Debug.Log("sTag="+sTag);
        if(!isSpawned)
        {
            return;
        }
        GameObject electric;
        GameObject obj;

        if (sTag == "Player")
        {
            electric = PlayerElectric;
        }
        else if(sTag=="Enemy")
        {
            electric = EnemyElectric;
        }
        else
        {
            return;
        }

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
        ChangeSpawner();
        //スポナー初期化
        isSpawned = false;
        timer = 0.0f;
    }
    public void Spawn(string sTag , Vector2 vec)
    {
        GameObject electric;
        GameObject obj;

        if (sTag == "Player")
        {
            electric = PlayerElectric;
        }
        else if (sTag == "Enemy")
        {
            electric = EnemyElectric;
        }
        else
        {
            return;
        }

        if (!isSpawned)
        {
            return;
        }

        if (vec.x == 0 && vec.y == 0)
        {
            Spawn(sTag);
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
    void ChangeSpawner()
    {
        if (eUp) eUp = false;
        else eUp = true;
        if (eDown) eDown = false;
        else eDown = true;
        if (eRight) eRight = false;
        eRight = true;
        if (eLeft) eLeft = false;
        eLeft = true;
    }
    public float GetTimer()
    {
        return timer;
    }
}
