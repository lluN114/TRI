using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
public class FlashingSprite : MonoBehaviour {
    Image image;    //Imageコンポーネント
    float bloom_cnt;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        /*
        bloom_cnt += Time.deltaTime * 2;
        light.intensity = Mathf.Sin(bloom_cnt);
        */
        //image.color=Color.white* Mathf.Abs(Mathf.Sin(Time.time));
        image.color = new Color(1f, 1f, 1f, Mathf.Abs(Mathf.Sin(Time.time)));
        
    }
}
