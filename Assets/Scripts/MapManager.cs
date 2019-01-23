
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public const int mapY = 5;

    public int stageNumber;
    public string stageName;

    //ブロックのオブジェクト
    public GameObject BlockObj;
    //電流作るのオブジェクト
    public GameObject ElectricObj;

    //マップのサイズ
    public int mapSize;
    //プレイヤー位置
    public Vector2 playerPosition;
    //エネミー位置
    public Vector2 enemyPosition;
    //ブロックの位置
    List<Vector2> blockPositions;
    //電流置きの位置
    List<Vector2> electricPositions;

    //オブジェクト
    List<GameObject> blockObjects;
    List<GameObject> electObjects;


    // Use this for initialization
    void Start()
    {
        stageName = "stage_" + stageNumber.ToString("D3");
        FileOpen(stageName);

        PutPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Initialize();
            FileOpen(stageName);
            PutPosition();
        }
    }

    void Initialize()
    {
        mapSize = 0;
        playerPosition = new Vector2();
        enemyPosition = new Vector2();
        blockPositions = new List<Vector2>();
        electricPositions = new List<Vector2>();
        if (blockObjects!=null)
        {
            foreach(GameObject obj in blockObjects)
            {
                Destroy(obj);
            }
        }
        else
        {
            blockObjects = new List<GameObject>();
        }

        if (electObjects!=null)
        {
            foreach(GameObject obj in electObjects)
            {
                Destroy(obj);
            }
        }
        else
        {
            electObjects = new List<GameObject>();
        }
    }

    void FileOpen(string file)
    {
        Initialize();

        //ステージの配置
        int x = 0, y = 0;
        string temp;
        temp = Resources.Load("Stages/"+file, typeof(TextAsset)).ToString();

        //1文字ずつ検索
        for (int i = 0; i < temp.Length; i++)
        {
            switch (temp[i])
            {
                case 'M'://マップ
                    mapSize = int.Parse(temp.Substring(i + 1, 2));
                    i += 2;
                    break;
                case 'P'://プレイヤー
                    playerPosition.x = int.Parse(temp.Substring(i + 1, 2))-mapSize/2;
                    i += 2;
                    playerPosition.y = int.Parse(temp.Substring(i + 1, 2))*-1+mapY-0.5f;
                    i += 2;
                    break;
                case 'E'://エネミー
                    enemyPosition.x = int.Parse(temp.Substring(i + 1, 2))-mapSize/2;
                    i += 2;
                    enemyPosition.y = int.Parse(temp.Substring(i + 1, 2))*-1+mapY-0.5f;
                    i += 2;
                    break;
                case 'B'://ブロック
                    x=int.Parse(temp.Substring(i + 1, 2))-mapSize/2;
                    i += 2;
                    y = int.Parse(temp.Substring(i + 1, 2))*-1+mapY;
                    i += 2;
                    blockPositions.Add(new Vector2(x-0.5f,y-0.5f));
                    break;
                case 'D'://電流
                    x = int.Parse(temp.Substring(i + 1, 2))-mapSize/2;
                    i += 2;
                    y = int.Parse(temp.Substring(i + 1, 2))*-1+mapY;
                    i += 2;
                    electricPositions.Add(new Vector2(x-0.5f, y-0.5f));
                    break;
            }
        }
    }
    //再配置
    void PutPosition()
    {
        //プレイヤー
        GameObject.Find("Player").gameObject.transform.position = playerPosition;

        //エネミー
        GameObject.Find("Enemy").gameObject.transform.position = enemyPosition;

        //ブロック
        for(int i = 0; i < blockPositions.Count; i++)
        {
            GameObject obj=Instantiate(BlockObj, blockPositions[i], Quaternion.identity)as GameObject;
            blockObjects.Add(obj);
        }

        //電流
        for (int i = 0; i < electricPositions.Count; i++)
        {
           GameObject obj= Instantiate(ElectricObj, electricPositions[i], Quaternion.identity)as GameObject;
            electObjects.Add(obj);
        }
    }
}