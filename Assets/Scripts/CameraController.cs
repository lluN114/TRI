using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //カメラの左右制限
    private const float CAM_LIMIT_X_MIN = -5;
    private const float CAM_LIMIT_X_MAX = 5;
    private const float TOUCH_ACCEPT_HEIGHT = 0.4f;
    private const float DRAG_POWER = 0.0005f;

    //タッチされた位置と離された位置を格納する変数
    private Vector2 touchPos;

    public Camera camera;

    //画面サイズ
    private Vector2 WinSize;

    // Use this for initialization
    void Start()
    {  
        WinSize = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        //タッチされたら
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Input.mousePosition.y / WinSize.y <= TOUCH_ACCEPT_HEIGHT)
            {
                touchPos = Input.mousePosition;
                Debug.Log("TOUCH!!!");
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.mousePosition.y / WinSize.y <= TOUCH_ACCEPT_HEIGHT)
            {
                Vector3 move = (Vector3)touchPos - Input.mousePosition;
                move.y = 0;
                move.z = -10;
                camera.gameObject.transform.position += move * DRAG_POWER;
                //移動制限
                if (camera.gameObject.transform.position.x <= CAM_LIMIT_X_MIN)
                {
                    camera.gameObject.transform.position = new Vector3(CAM_LIMIT_X_MIN, 0,-10);
                }
                if (camera.gameObject.transform.position.x >= CAM_LIMIT_X_MAX)
                {
                    camera.gameObject.transform.position = new Vector3(CAM_LIMIT_X_MAX, 0,-10);
                }
            }
        }
    } 
}
