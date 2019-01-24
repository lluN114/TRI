//FadeManager.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{

    //フェード用のCanvas
    private static Canvas fadeCanvas;

    //フェードインアウトのフラグ
    public static bool isFadeIn = false;
    public static bool isFadeOut = false;
    public static bool isFadeReady = false;

    //フェードしたい時間（単位は秒）
    private static float fadeTime = 0.5f;

    //遷移先のシーン番号
    private static int nextScene = 1;

    //開閉する扉のImage
    private static Image doorLeftImage;
    private static Image doorRightImage;

    //開閉する扉の距離
    private static float doorDistance;

    //待ち時間
    private static float waitTime;
    private static bool isWait;

    //カウントダウン関連
    private static Image countDawnImageReady;
    private static Image countDawnImageGo;
    private static float countDownWaitTime;
    private static bool isCountDownWait;

    //終了してゲームがスタートできるかどうか
    public static bool isGameStart = false;

    //サイズ調整関連
    //画面サイズひっぱてきて倍率で画像サイズドーン
    //基本は画像サイズで取ってあるからそれで大丈夫なはず

    //フェード用のCanvasとImage生成
    static void Init()
    {
        //フェード用のCanvas生成
        GameObject FadeCanvasObject = new GameObject("CanvasFade");
        fadeCanvas = FadeCanvasObject.AddComponent<Canvas>();
        FadeCanvasObject.AddComponent<GraphicRaycaster>();
        fadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        FadeCanvasObject.AddComponent<FadeManager>();

        //最前面になるよう適当なソートオーダー設定
        fadeCanvas.sortingOrder = 100;

        //扉用のイメージを二つ作成
        doorLeftImage = new GameObject("doorImageLeft").AddComponent<Image>();
        doorLeftImage.sprite = Resources.Load<Sprite>("Sprite/shutter_3");
        doorLeftImage.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        doorLeftImage.transform.SetParent(fadeCanvas.transform, false);

        doorRightImage = new GameObject("doorImageRight").AddComponent<Image>();
        doorRightImage.sprite = Resources.Load<Sprite>("Sprite/shutter_4");
        doorRightImage.rectTransform.sizeDelta = new Vector2(Screen.width,Screen.height);
        doorRightImage.transform.SetParent(fadeCanvas.transform, false);

        //待ち状態
        waitTime = 0;
        isWait = false;

        //カウントダウンイメージのロードと設定
        countDawnImageGo = new GameObject("countDownGo").AddComponent<Image>();
        countDawnImageGo.sprite = Resources.Load<Sprite>("Sprite/go");
        countDawnImageGo.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        countDawnImageGo.transform.SetParent(fadeCanvas.transform, false);
        countDawnImageGo.enabled = false;

        countDawnImageReady = new GameObject("countDownReady").AddComponent<Image>();
        countDawnImageReady.sprite = Resources.Load<Sprite>("Sprite/ready");
        countDawnImageReady.rectTransform.sizeDelta = new Vector2(Screen.width,Screen.height);
        countDawnImageReady.transform.SetParent(fadeCanvas.transform, false);
        countDawnImageReady.enabled = false;

        countDownWaitTime = 0;
        isCountDownWait = false;

        isGameStart = true;
    }

    //フェードイン開始
    public static void FadeIn()
    {
        if (doorLeftImage == null) Init();
        isFadeIn = true;
        
        /*
        doorLeftImage.rectTransform.localPosition = new Vector3(
        doorLeftImage.rectTransform.localPosition.x,
        doorLeftImage.rectTransform.localPosition.y,
        doorLeftImage.rectTransform.localPosition.z
        );

        doorRightImage.rectTransform.localPosition = new Vector3(
            doorRightImage.rectTransform.localPosition.x,
            doorRightImage.rectTransform.localPosition.y,
            doorRightImage.rectTransform.localPosition.z
            );
            */
    }

    //フェードアウト開始
    public static void FadeOut(int n)
    {
        if (doorLeftImage == null) Init();
        nextScene = n;
        fadeCanvas.enabled = true;
        isFadeOut = true;

        doorDistance = doorLeftImage.rectTransform.rect.width/*-(240*320/690)*/;

        doorLeftImage.rectTransform.localPosition = new Vector3(
            Camera.main.transform.position.x - doorDistance,
            doorLeftImage.rectTransform.localPosition.y,
            doorLeftImage.rectTransform.localPosition.z
            );

        doorRightImage.rectTransform.localPosition = new Vector3(
            Camera.main.transform.position.x + doorDistance,
            doorRightImage.rectTransform.localPosition.y,
            doorRightImage.rectTransform.localPosition.z
            );

        countDawnImageReady.enabled = false;
        countDawnImageGo.enabled = false;
    }

    public static void FadeReady()
    {
        isFadeReady = true;
        FadeIn();
    }

    void Update()
    {
        //フラグ有効なら毎フレームフェードイン/アウト処理
        if (isFadeIn)
        {
            if (isFadeReady)
                countDawnImageReady.enabled = true;
            //扉移動距離計算
            float dst = (Time.deltaTime / fadeTime) * doorDistance;

            //フェードイン終了判定
            if (doorLeftImage.rectTransform.localPosition.x <= -1 * doorDistance)
            {
                isFadeIn = false;
                if(isFadeReady==false)fadeCanvas.enabled = false;
            }

            //フェードイン扉移動
            doorLeftImage.rectTransform.localPosition = new Vector3(
                doorLeftImage.rectTransform.localPosition.x - dst,
                doorLeftImage.rectTransform.localPosition.y,
                doorLeftImage.rectTransform.localPosition.z
            );

            doorRightImage.rectTransform.localPosition = new Vector3(
                doorRightImage.rectTransform.localPosition.x + dst,
                doorRightImage.rectTransform.localPosition.y,
                doorRightImage.rectTransform.localPosition.z
                );
        }

        if (isFadeIn == false && isFadeReady == true)
        {
            countDownWaitTime += Time.deltaTime;
            if(!isCountDownWait)countDawnImageReady.enabled = true;

            if (countDownWaitTime >= 1)
            {
                countDawnImageReady.enabled = false;
                countDawnImageGo.enabled = true;
                countDownWaitTime = 0;

                if (isCountDownWait == true)
                {
                    isFadeReady = false;
                    isCountDownWait = false;
                    fadeCanvas.enabled = false;
                }

                isCountDownWait = true;
            }
        }

        if (isFadeOut)
        {
            //扉の移動距離計算
            float dst = (Time.deltaTime / fadeTime) * doorDistance;

            if (isWait == false)
            {
                //ポジション変更
                doorLeftImage.rectTransform.localPosition = new Vector3(
                    doorLeftImage.rectTransform.localPosition.x + dst,
                    doorLeftImage.rectTransform.localPosition.y,
                    doorLeftImage.rectTransform.localPosition.z
                );

                doorRightImage.rectTransform.localPosition = new Vector3(
                    doorRightImage.rectTransform.localPosition.x - dst,
                    doorRightImage.rectTransform.localPosition.y,
                    doorRightImage.rectTransform.localPosition.z
                    );
            }

            //フェードアウト終了判定
            if (doorLeftImage.rectTransform.localPosition.x >= 0)
            {
                waitTime += Time.deltaTime;
                isWait = true;
            }

            if (waitTime >= 1)
            {
                isFadeOut = false;

                //次のシーンへ遷移
                SceneManager.LoadScene(nextScene);
            }
        }
    }
    public static bool GetGameStart()
    {
        return isGameStart;
    }
}