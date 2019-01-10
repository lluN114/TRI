using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    
    public SpriteRenderer sp;
    public Electric electric;

    float destroyTimer;
    const float destroyTimerLimit = 1.0f;
    bool isAction;
    //Use this for initialization
    public void Start()
    {
        gameObject.tag = "Block";
        gameObject.layer = 15;
        destroyTimer = 0.0f;
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyState();
    }

    /// <summary>
    /// 電流を取得
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public virtual Electric GetElectric(GameObject obj)
    {
            return obj.GetComponent<Electric>();
    }

    /// <summary>
    /// 本ブロックのメイン機能
    /// </summary>
    public virtual void BlockAction()
    {

    }

    /// <summary>
    /// 消滅までの機能
    /// </summary>
    public virtual void DestroyState()
    {
        if (isAction)
        {
            destroyTimer += Time.deltaTime;
            sp.color = new Color(1, 1, 1, destroyTimerLimit - destroyTimer);
            if (destroyTimer >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //電気が衝突したとき
        if (c.tag == "Electric")
        {
            Debug.Log("hit" + c.name);

            electric = GetElectric(c.gameObject);

            BlockAction();

            isAction = true;
        }
    }
}
