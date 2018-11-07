//FadeManager.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{

    //フェード用のCanvasとImage
    private static Canvas fadeCanvas;
    private static Image fadeImage;


    //フェード用Imageの透明度
    private static float alpha = 0.0f;

    //フェードインアウトのフラグ
    public static bool isFadeIn = false;
    public static bool isFadeOut = false;

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

        //フェード用のImage生成
        fadeImage = new GameObject("ImageFade").AddComponent<Image>();
        fadeImage.transform.SetParent(fadeCanvas.transform, false);
        fadeImage.rectTransform.anchoredPosition = Vector3.zero;

        //Imageのサイズは適当に設定してください
        fadeImage.rectTransform.sizeDelta = new Vector2(1920, 1080);

        //扉用のイメージを二つ作成
        doorLeftImage = new GameObject("doorImageLeft").AddComponent<Image>();
        doorLeftImage.sprite = Resources.Load<Sprite>("Sprite/shutter_2");
        doorLeftImage.rectTransform.sizeDelta = new Vector2(320, 320);
        doorLeftImage.transform.SetParent(fadeCanvas.transform, false);
        //doorLeftImage.rectTransform.localScale = new Vector3(-1,1,1);

        doorRightImage = new GameObject("doorImageRight").AddComponent<Image>();
        doorRightImage.sprite = Resources.Load<Sprite>("Sprite/shutter_3");
        doorRightImage.rectTransform.sizeDelta = new Vector2(320, 320);
        doorRightImage.transform.SetParent(fadeCanvas.transform, false);
        //doorRightImage.rectTransform.localScale = new Vector3(-1, 1, 1);

        //待ち状態
        waitTime = 0;
        isWait = false;
    }

    //フェードイン開始
    public static void FadeIn()
    {
        if (fadeImage == null) Init();
        fadeImage.color = Color.clear;
        isFadeIn = true;
        
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
    }

    //フェードアウト開始
    public static void FadeOut(int n)
    {
        if (fadeImage == null) Init();
        nextScene = n;
        fadeImage.color = Color.clear;
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

    }

    void Update()
    {
        //フラグ有効なら毎フレームフェードイン/アウト処理
        if (isFadeIn)
        {
            //経過時間から透明度計算
            //alpha -= Time.deltaTime / fadeTime;
            float dst = (Time.deltaTime / fadeTime) * doorDistance;

            //フェードイン終了判定
            if (doorLeftImage.rectTransform.localPosition.x <= -1*doorDistance*2)
            {
                isFadeIn = false;
                //alpha = 0.0f;
                fadeCanvas.enabled = false;
            }



            //フェード用Imageの透明度設定
            //fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            
                //ポジション変更
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
        else if (isFadeOut)
        {
            //経過時間から透明度計算
            //alpha += Time.deltaTime / fadeTime;
            float dst = (Time.deltaTime / fadeTime) * doorDistance;

            //フェードアウト終了判定
            if (doorLeftImage.rectTransform.localPosition.x >= 0)
            {
                waitTime += Time.deltaTime;
                isWait = true;
                Debug.Log(waitTime);
            }

            if (waitTime>=1)
            {
                isFadeOut = false;
                //alpha = 1.0f;

                //次のシーンへ遷移
                SceneManager.LoadScene(nextScene);
            }

            //フェード用Imageの透明度設定
            //fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);

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
        }
    }
}