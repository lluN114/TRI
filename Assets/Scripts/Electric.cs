using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{
    public int turnLimit;//ターン回数
    private int currentTurn;//現在のターン回数
    public float speed;//速度
    public Vector2 forward;//方向
    public float acceleration;//加速度

    SpriteRenderer sp;//画像
    //public Sprite UpSprite;
    //public Sprite LeftSprite;
    Animator an;
    public RuntimeAnimatorController UpAnimation;
    //public RuntimeAnimatorController DownAnimation;
    public RuntimeAnimatorController LeftAnimation;
    //public RuntimeAnimatorController RightAnimation;

    //屈折時に呼び出すオブジェクト
    public GameObject refractionObj;
    //破壊時に呼び出すオブジェクトのパスとオブジェクト
    public GameObject ExplosionObj;

    bool isTurned;

    // Use this for initialization
    public virtual void Start()
    {
        //currentTurn = 0;
        speed = 3.0f;
        turnLimit = 3;
        acceleration = 1.2f;
        sp=GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        SpriteChange(forward);
    }


    // Update is called once per frame
    public virtual void Update()
    {

        Move();
    }
    void Move()
    {
        transform.Translate(forward * speed * acceleration * (currentTurn+1) * Time.deltaTime);
    }
    public void TurnForward(float x=0, float y=0)
    {
        //ターン回数が上限を超えていなければターンする
        if (currentTurn < turnLimit)
        {
            if (x == 0 && y == 0)
            {
                transform.Translate(-forward * speed * acceleration * Time.deltaTime*2);
                CloneElectric(new Vector2(-forward.y, -forward.x));
                CloneElectric(new Vector2(forward.y, forward.x));
                //forward = new Vector2(forward.y, forward.x);
                Explosion();
            }
            else
            {
                forward.x = x;
                forward.y = y;
            }
            currentTurn++;
            SpriteChange(forward);
            Reflaction();
        }
        else
        {
            Explosion();
        }
    }
    //屈折呼び出し
    void Reflaction()
    {
        if (refractionObj != null)
            Instantiate(refractionObj, transform.position, transform.rotation);
    }
    //爆破
    public virtual void Explosion()
    {
        if (ExplosionObj != null)
            Instantiate(ExplosionObj, transform.position, transform.rotation);

        Destroy(gameObject);
    }
    //自身のコピーを作って逆方向に生成
    void CloneElectric(Vector2 dir)
    {
        GameObject obj = Instantiate(this.gameObject, transform.position, transform.rotation)as GameObject;
        Electric elec = obj.GetComponent<Electric>();
        elec.forward = dir;
        elec.currentTurn = currentTurn+1;
    }
    //画像の変更
    void SpriteChange(Vector2 dir)
    {
        if (forward.x > 0)
        {//右方向
            an.runtimeAnimatorController = LeftAnimation;
            //sp.sprite = LeftSprite;
            sp.flipX = true;
        }
        else if (forward.x < 0)
        {//左方向
            an.runtimeAnimatorController = LeftAnimation;
            //sp.sprite = LeftSprite;
            sp.flipX = false;
        }
        else if (forward.y > 0)
        {//上方向
            an.runtimeAnimatorController = UpAnimation;
            //sp.sprite = UpSprite;
            sp.flipY = false;
        }
        else if (forward.y < 0)
        {//下方向
            an.runtimeAnimatorController = UpAnimation;
            //sp.sprite = UpSprite;
            sp.flipY = true;
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D c)
    {
        //Debug.Log("WTF!" + c.name);
        if (c.gameObject.layer == 13)
        {
            TurnForward();
        }
    }
    void OnTriggerStay2D(Collider2D c)
    {

    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.layer == 13)
        {
        }
    }
}
