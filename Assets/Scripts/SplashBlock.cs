using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashBlock : Block
{

    public override void BlockAction()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Instantiate(electric.gameObject,transform.position,transform.rotation)as GameObject;
            switch (i)
            {
                case 0:
                    obj.GetComponent<Electric>().TurnForward(new Vector2(-1, 0));
                    break;
                case 1:
                    obj.GetComponent<Electric>().TurnForward(new Vector2(1, 0));
                    break;
                case 2:
                    obj.GetComponent<Electric>().TurnForward(new Vector2(0, -1));
                    break;
                case 3:
                    obj.GetComponent<Electric>().TurnForward(new Vector2(0, 1));
                    break;
                default:
                    break;
            }
        }
    }
}
