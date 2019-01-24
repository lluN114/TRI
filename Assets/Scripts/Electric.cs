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

    //コライダー
    public BoxCollider2D boxCollider;
    public const float colX = 1.8f, colY = 0.0f;
    public const float sizeX = 1, sizeY = 0.6f;

    //屈折時に呼び出すオブジェクト
    public GameObject refractionObj;
    //破壊時に呼び出すオブジェクトのパスとオブジェクト
    public GameObject ExplosionObj;

    bool isTurned;

    //時間制限
    public float destroyLimit = 5.0f;
    //経過時間
    public float destTimer = 0.0f;

    // Use this for initialization
    public virtual void Start()
    {
        ////currentTurn = 0;
        destTimer = 0;
        speed = 1.2f;
        turnLimit = 3;
        acceleration = 1.005f;
        sp = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        SpriteChange(forward);
    }


    // Update is called once per frame
    public virtual void Update()
    {
        destTimer += Time.deltaTime;
        if (destTimer >= destroyLimit)
        {
            Destroy(gameObject);
        }

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
            transform.Translate(-forward *speed/10);

            if (x == 0 && y == 0)
            {
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
            Reflaction();
            SpriteChange(forward);
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
        {
            Vector2 pos = new Vector2(transform.position.x + boxCollider.offset.x, transform.position.y + boxCollider.offset.y);
            Instantiate(refractionObj, pos, transform.rotation);
        }
    }
    //爆破
    public virtual void Explosion()
    {
        if (ExplosionObj != null)
                Instantiate(ExplosionObj, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
    //自身のコピーを作って逆方向に生成
    void CloneElectric(Vector2 dir)
    {
        Vector2 position = new Vector2(transform.position.x , transform.position.y );
        GameObject obj = Instantiate(this.gameObject, position, transform.rotation)as GameObject;
        Electric elec = obj.GetComponent<Electric>();
        elec.forward = dir;
        obj.transform.Translate(-dir);
        elec.currentTurn = currentTurn+1;
    }
    //画像の変更
    void SpriteChange(Vector2 dir)
    {
        if (forward.x > 0)
        {//右方向
            an.runtimeAnimatorController = LeftAnimation;
            boxCollider.offset = new Vector2(colX, colY);
            boxCollider.size = new Vector2(sizeX, sizeY);
            //sp.sprite = LeftSprite;
            sp.flipX = true;
            sp.flipY = false;
        }
        else if (forward.x < 0)
        {//左方向
            an.runtimeAnimatorController = LeftAnimation;
            boxCollider.offset = new Vector2(-colX, colY);
            boxCollider.size = new Vector2(sizeX, sizeY);
            //sp.sprite = LeftSprite;
            sp.flipX = false;
            sp.flipY = false;
        }
        else if (forward.y > 0)
        {//上方向
            an.runtimeAnimatorController = UpAnimation;
            boxCollider.offset = new Vector2(colY, colX);
            boxCollider.size = new Vector2(sizeY, sizeX);
            //sp.sprite = UpSprite;
            sp.flipY = false;
        }
        else if (forward.y < 0)
        {//下方向
            an.runtimeAnimatorController = UpAnimation;
            boxCollider.offset = new Vector2(colY, -colX);
            boxCollider.size = new Vector2(sizeY, sizeX);
            //sp.sprite = UpSprite;
            sp.flipY = true;
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 13)
        {
            transform.position=(transform.position-c.gameObject.transform.position).normalized+transform.position;
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
