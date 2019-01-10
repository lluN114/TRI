using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//その方向に強制的に移動させるマス
public class TurnBlock : Block {

    public Vector2 forward;


    // Use this for initialization
    public void Start()
    {
   
    }

    public override void BlockAction()
    {
        base.BlockAction();
    }
}
