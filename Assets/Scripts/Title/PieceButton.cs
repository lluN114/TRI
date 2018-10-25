using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PieceButton : BaseButton
{
    public SceneTransition t;

    protected override void OnClick(string objectName)
    {
        if ("start".Equals(objectName))
        {
            // Button1がクリックされたとき
            t.Trans("GameScene");
            Debug.Log("start");
        }
        else if ("exit".Equals(objectName))
        {
            // Button2がクリックされたとき
            Debug.Log("exit");
            Application.Quit();
        }
        else
        {
            throw new System.Exception("Not implemented!!");
        }
    }
}
