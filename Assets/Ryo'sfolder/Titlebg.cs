using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titlebg : MonoBehaviour {

    Camera cam;

    //[SerializeField]
    float height;
    //[SerializeField]
    float width;

    float timer_v,timer_h;//タイマー
    float spawn_time_v,spawn_time_h;//random

    [Header("スポーン時間のminとmax")]
    public float[] between_spawn_time = new float[2]; 

    [Header("横に流れる球の個数")]
    public float ball_Vertical;
    [Header("縦に流れる球の個数")]
    public float ball_horizontal;

    //[SerializeField]
    List<Vector3> heightPos = new List<Vector3>();
    //[SerializeField]
    List<Vector3> widthPos = new List<Vector3>();

    public GameObject Electoric_ball;

    // Use this for initialization

    void Start () {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //画面の縦横サイズ取得

        for (int i = 1;i < ball_Vertical + 1;i++)//等間隔の縦Pos取得
        {
            //heightPos.Add(height / (ball_Vertical + 1) * i);
            heightPos.Add(cam.ViewportToWorldPoint(new Vector3(0,1/(ball_Vertical + 1) * i,10)));
        }

        for (int i = 1; i < ball_horizontal + 1; i++)//等間隔の横Pos取得
        {
            //widthPos.Add(width / (ball_horizontal + 1) * i);
            widthPos.Add(cam.ViewportToWorldPoint(new Vector3(1 / (ball_horizontal + 1) * i, 0, 10)));
        }

    }

    // Update is called once per frame
    void Update () {
        timer_v += Time.deltaTime;
        spawn_time_v = Random.Range(between_spawn_time[0],between_spawn_time[1]);
        if (timer_v > spawn_time_v)
        {
            Vertical_Electoric();//横に流れる電流
            timer_v = 0;
        }

        timer_h += Time.deltaTime;
        spawn_time_h = Random.Range(between_spawn_time[0], between_spawn_time[1]);
        if (timer_h > spawn_time_h)
        {
            Horizontal_Electoric();//縦に流れる電流
            timer_h = 0;
        }

    }

    void Vertical_Electoric()
    {
        GameObject EB_v;
        int anti_flag_v = 0;
        anti_flag_v = Random.Range(0, 4);
        anti_flag_v = (anti_flag_v > 2) ? 1 : 0;
        switch (anti_flag_v)//0:正方向 1:反対方向
        {
            case 0:
                EB_v = Instantiate(Electoric_ball, heightPos[(int)Random.Range(0, ball_Vertical)], Quaternion.EulerAngles(0, 90, 90));
                break;

            case 1:
                EB_v = Instantiate(Electoric_ball, -heightPos[(int)Random.Range(0, ball_horizontal)], Quaternion.EulerAngles(0, -90, -90));
                break;

            default:
                break;
        }
    }

    void Horizontal_Electoric()
    {
        GameObject EB_h;
        int anti_flag_h = 0;
        anti_flag_h = Random.Range(0, 4);
        anti_flag_h = (anti_flag_h > 2) ? 1 : 0;
        switch (anti_flag_h)//0:正方向 1:反対方向
        {
            case 0:
                EB_h = Instantiate(Electoric_ball, widthPos[(int)Random.Range(0, ball_horizontal)], Quaternion.EulerAngles(-90, 0, 0));
                break;

            case 1:
                EB_h = Instantiate(Electoric_ball, -widthPos[(int)Random.Range(0, ball_horizontal)], Quaternion.EulerAngles(90, 0, 0));
                break;

            default:
                break;
        }

    }
}
