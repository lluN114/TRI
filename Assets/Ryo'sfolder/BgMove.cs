using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour {

    [SerializeField, Range(0, 10)]
    float time = 1;
    
    [SerializeField]
    Vector3 endPosition;

    //[SerializeField]
    //AnimationCurve curve;

    private float startTime;
    private Vector3 startPosition;

    public GameObject Lightning;

    RectTransform rect;

    void OnEnable()
    {

        rect = GetComponent<RectTransform>();
        if (time <= 0)
        {
            //rect.localPosition = endPosition;
            
            enabled = false;
            return;
        }

        startTime = Time.timeSinceLevelLoad;
       // startPosition = rect.localPosition;
    }

    void Update()
    {
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > time)
        {
            rect.localPosition = endPosition;
            if (transform.name == "Lose") GetComponent<SinWave>().enabled = true;
            if (transform.name == "Win") Lightning.SetActive(true);
            enabled = false;
        }

        var rate = diff / time;
        //var pos = curve.Evaluate(rate);

        rect.localPosition = Vector3.Lerp(startPosition, endPosition, rate);
        //transform.position = Vector3.Lerp (startPosition, endPosition, pos);
    }
}
