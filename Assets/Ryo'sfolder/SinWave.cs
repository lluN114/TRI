using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWave : MonoBehaviour {
    public float x = 2f;
    RectTransform rect;
    // Use this for initialization
    void Start () {
        rect = GetComponent<RectTransform>();	
	}
	
	// Update is called once per frame
	void Update () {
        rect.localPosition = new Vector3(rect.localPosition.x
   , Mathf.Sin(Time.frameCount * x) * 25f + 25f, rect.localPosition.z);
    }
}
